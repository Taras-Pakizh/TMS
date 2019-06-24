using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TMS.Client.ViewModels;
using TMS.Data;
using TMS.ViewModels;
using TMS.Client.Validation;
using AutoMapper;

namespace TMS.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        #region Properties

        private ViewReport _report { get; set; }

        private ReportOperation _operation { get; set; }

        private UserView _engineer { get; set; }

        private ModelValidator _validator = new ModelValidator();

        private ApplicationView Context
        {
            get { return (ApplicationView)DataContext; }
        }
        
        #endregion

        #region DependencyProperty

        public static readonly DependencyProperty TasksProperty;
        public IEnumerable<ViewTask> Tasks
        {
            get { return (IEnumerable<ViewTask>)GetValue(TasksProperty); }
            set { SetValue(TasksProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty;
        public string Header
        {
            get { return (string) GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty ActiveProperty;
        public bool Active
        {
            get { return (bool)GetValue(ActiveProperty); }
            set { SetValue(ActiveProperty, value); }
        }

        static ReportWindow()
        {
            TasksProperty = DependencyProperty.Register(
                nameof(Tasks), typeof(IEnumerable<ViewTask>), typeof(ReportWindow));
            HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(string), typeof(ReportWindow));
            ActiveProperty = DependencyProperty.Register(nameof(Active), typeof(bool), typeof(ReportWindow));
        }

        #endregion

        public ReportWindow(ViewReport report, ReportOperation operation, UserView engineer, IEnumerable<ViewTask> tasks)
        {
            InitializeComponent();

            _report = report;
            if (_report == null)
                _report = new ViewReport();
            _operation = operation;
            _engineer = engineer;

            Tasks = tasks;
            switch (operation)
            {
                case ReportOperation.Add:
                    Header = "Create report";
                    Active = true;
                        break;
                case ReportOperation.Update:
                    Header = "Update report";
                    SetForm(_report);
                    Active = true;
                        break;
                case ReportOperation.Delete:
                    Header = "Delete this report?";
                    SetForm(_report);
                    Active = false;
                        break;
            }
        }

        private void SetForm(ViewReport view)
        {
            ComboBox_Tasks.SelectedItem = Tasks.Where(x => x.Id == view.taskId).Single();
            ComboBox_Activity.SelectedItem = view.activity;
            DateTimePicker_BeginTime.Value = view.start;
            DateTimePicker_EndTime.Value = view.end;
            RichTextBox_Description.Document.Blocks.Clear();
            RichTextBox_Description.Document.Blocks.Add(new Paragraph(new Run(view.description)));
        }

        private ViewReport ReadForm()
        {
            var model = new ReportValidationModel()
            {
                task = ComboBox_Tasks.SelectedItem as ViewTask,
                activity = ComboBox_Activity.SelectedItem as ActivityType?,
                start = DateTimePicker_BeginTime.Value,
                end = DateTimePicker_EndTime.Value,
                description = new TextRange(RichTextBox_Description.Document.ContentStart,
                    RichTextBox_Description.Document.ContentEnd).Text
            };

            if (!_validator.IsModelValid(model))
            {
                Label_Error_list.Content = _validator.ValidationResults;
                return null;
            }

            _report.taskId = model.task.Id;
            _report.activity = (ActivityType)model.activity;
            _report.start = (DateTime)model.start;
            _report.end = (DateTime)model.end;
            _report.description = model.description;

            if(_operation != ReportOperation.Delete)
            {
                _report.status = ReportStatus.Open;
            }

            _report.engineerId = Context.CurrentUser.Id;
            _report.effort = CalculateEffort(_report.start, _report.end);

            return _report;
        }

        private double CalculateEffort(DateTime start, DateTime end)
        {
            var dayStartsHour = new TimeSpan(10, 0, 0);
            var dayEndsHour = new TimeSpan(18, 0, 0);
            var FullDay = new TimeSpan(8, 0, 0);

            var firstDay = dayEndsHour - start.TimeOfDay;
            if (firstDay < new TimeSpan(0, 0, 0))
                firstDay = new TimeSpan();
            else if (firstDay > FullDay)
                firstDay = FullDay;

            var lastDay = end.TimeOfDay - dayStartsHour;
            if (lastDay < new TimeSpan(0, 0, 0))
                lastDay = new TimeSpan();
            if (lastDay > FullDay)
                lastDay = FullDay;

            var time = new TimeSpan();
            for(DateTime day = start.Date.AddDays(1); day.Date < end.Date; day = day.AddDays(1))
            {
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                time = time.Add(FullDay);
            }

            return firstDay.TotalHours + lastDay.TotalHours + time.TotalHours;
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            var view = ReadForm();
            if (view == null)
                return;

            var report = Mapper.Map<ViewReport, ReportView>(view);

            bool result = false;

            switch (_operation)
            {
                case ReportOperation.Add:
                    result = await Context.Add(report); break;
                case ReportOperation.Update:
                    result = await Context.Update(report); break;
                case ReportOperation.Delete:
                    result = await Context.Delete<ReportView>(report.Id); break;
            }

            this.Hide();

            string message = "Operation ";
            if (result)
                message += "succeeded";
            else message += "failed";
            MessageBox.Show(message);

            this.Close();
        }
    }
}
