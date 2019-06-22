using System;
using System.Collections.Generic;
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
using TMS.ViewModels;
using TMS.Client;
using System.Threading;
using TMS.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using TMS.Client.Attributes;

namespace TMS.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для EngineerWindow.xaml
    /// </summary>
    public partial class EngineerWindow : Window
    {
        private ApplicationView Context
        {
            get { return (ApplicationView)DataContext; }
        }

        public EngineerWindow()
        {
            InitializeComponent();
        }

        #region Events

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Context.GetAll<ReportView>();
            await Context.GetAll<TaskView>();
            await Context.GetAll<ProjectView>();
            await Context.MapToUI();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var attributes = ((PropertyDescriptor)e.PropertyDescriptor).Attributes.OfType<AutoGenerateAttribute>();
            
            if (attributes == null)
                e.Column.Visibility = Visibility.Collapsed;
            else
            {
                var attribute = attributes.Single();
                if (attribute.IsVisible)
                {
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Header = attribute.Header;
                    e.Column.DisplayIndex = attribute.Index;
                }
                else
                {
                    e.Column.Visibility = Visibility.Hidden;
                }
            }
        }

        private void OpenTask_Click(object sender, RoutedEventArgs e)
        {
            var report = ((Button)sender).DataContext as ViewReport;
            var task = ((Button)sender).DataContext as ViewTask;

            ViewTask view;
            if (report != null) view = Context.ViewTasks.Where(x => x.Id == report.taskId).Single();
            else if (task != null) view = task;
            else return;

            var window = new TaskWindow(view);
            window.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewReports_Click(object sender, RoutedEventArgs e)
        {
            var view = ((Button)sender).DataContext as ViewTask;
            Filter_Tasks.SelectedItem = view;
            Button_ReportFilter.Command.Execute(Button_ReportFilter.CommandParameter);
            TabControl_Global.SelectedIndex = 0;
        }

        private void ViewTasks_Click(object sender, RoutedEventArgs e)
        {
            var view = ((Button)sender).DataContext as ViewProject;
            Filter_Project.SelectedItem = view;
            Context.FilterTask.Execute(view);
            TabControl_Global.SelectedIndex = 2;
        }

        #endregion
    }
}
