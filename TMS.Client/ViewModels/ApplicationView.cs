using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TMS.Data;
using TMS.Services;
using TMS.ViewModels;
using Task = System.Threading.Tasks.Task;
using TaskData = TMS.Data.Task;
using System.Reflection;
using AutoMapper;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace TMS.Client.ViewModels
{
    class ApplicationView:BaseView
    {
        private ProxyWebApi _client = new ProxyWebApi();

        public ApplicationView()
        {
            Mapping.Initialize();
        }

        public ProxyWebApi Proxy { get { return _client; } }

        #region Properties

        private bool _IsAuthorized;
        public bool IsAuthorized
        {
            get { return _IsAuthorized; }
            set
            {
                _IsAuthorized = value;
                OnPropertyChanged(nameof(IsAuthorized));
            }
        }

        private Role _role;
        public Role Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        private UserView _currentUser;
        public UserView CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        private ObservableCollection<ReportView> _Reports;
        public ObservableCollection<ReportView> Reports
        {
            get { return _Reports; }
            set
            {
                _Reports = value;
                OnPropertyChanged(nameof(Reports));
            }
        }

        private ObservableCollection<ViewReport> _ViewReports;
        public ObservableCollection<ViewReport> ViewReports
        {
            get { return _ViewReports; }
            set
            {
                _ViewReports = value;
                OnPropertyChanged(nameof(ViewReports));
            }
        }

        private ObservableCollection<ViewReport> _ShowingReports;
        public ObservableCollection<ViewReport> ShowingReports
        {
            get { return _ShowingReports; }
            set
            {
                _ShowingReports = value;
                OnPropertyChanged(nameof(ShowingReports));
            }
        }

        private ObservableCollection<ProjectView> _Projects;
        public ObservableCollection<ProjectView> Projects
        {
            get { return _Projects; }
            set
            {
                _Projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }

        private ObservableCollection<ViewProject> _ViewProjects;
        public ObservableCollection<ViewProject> ViewProjects
        {
            get { return _ViewProjects; }
            set
            {
                _ViewProjects = value;
                OnPropertyChanged(nameof(ViewProjects));
            }
        }

        private ObservableCollection<ViewProject> _ShowingProjects;
        public ObservableCollection<ViewProject> ShowingProjects
        {
            get { return _ShowingProjects; }
            set
            {
                _ShowingProjects = value;
                OnPropertyChanged(nameof(ShowingProjects));
            }
        }

        private ObservableCollection<TaskView> _Tasks;
        public ObservableCollection<TaskView> Tasks
        {
            get { return _Tasks; }
            set
            {
                _Tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        private ObservableCollection<ViewTask> _ViewTasks;
        public ObservableCollection<ViewTask> ViewTasks
        {
            get { return _ViewTasks; }
            set
            {
                _ViewTasks = value;
                OnPropertyChanged(nameof(ViewTasks));
            }
        }

        private ObservableCollection<ViewTask> _ShowingTasks;
        public ObservableCollection<ViewTask> ShowingTasks
        {
            get { return _ShowingTasks; }
            set
            {
                _ShowingTasks = value;
                OnPropertyChanged(nameof(ShowingTasks));
            }
        }

        #endregion

        #region Psevdo_Commands

        public async Task<bool> GetAll<T>() where T : IViewBase
        {
            try
            {
                var collection = new ObservableCollection<T>(await _client.GetAllAsync<T>());
                var type = typeof(T);
                var property = this.GetType().GetProperty(type.Name.Substring(0, type.Name.IndexOf("View")) + "s");
                property.SetValue(this, collection);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Add<T>(T view) where T : IViewBase
        {
            return await _client.AddAsync(view);
        }

        public async Task<bool> Update<T>(T view) where T : IViewBase
        {
            return await _client.UpdateAsync(view);
        }

        public async Task<bool> Delete<T>(int id) where T : IViewBase
        {
            return await _client.DeleteAsync<T>(id);
        }

        public async Task Authorization(AuthorizationModel model)
        {
            IsAuthorized = false;
            if (_client.Authorization(model.username, model.password))
            {
                IsAuthorized = true;
                Role = await _client.GetRoleAsync();
                CurrentUser = await _client.GetCurrentUser(model.username);
            }
        }

        public async Task MapToUI()
        {
            await Task.Run(() =>
            {
                Mapping.SetContext(Reports, Tasks, Projects);

                var viewReports = Mapper.Map<IEnumerable<ReportView>, IEnumerable<ViewReport>>(Reports
                    .Where(x => x.engineerId == CurrentUser.Id));
                var viewTasks = Mapper.Map<IEnumerable<TaskView>, IEnumerable<ViewTask>>(Tasks);
                var viewProjects = Mapper.Map<IEnumerable<ProjectView>, IEnumerable<ViewProject>>(Projects);

                ViewReports = new ObservableCollection<ViewReport>(viewReports);
                ViewTasks = new ObservableCollection<ViewTask>(viewTasks);
                ViewProjects = new ObservableCollection<ViewProject>(viewProjects);

                ShowingTasks = ViewTasks;
                ShowingReports = ViewReports;
                ShowingProjects = ViewProjects;
            });
        }

        public async Task Download<T>() where T : IViewBase
        {
            await GetAll<T>();
            var type = typeof(T);

            await Task.Run(() =>
            {
                var MainProperty = this.GetType().GetProperty
                (type.Name.Substring(0, type.Name.IndexOf("View")) + "s");

                Mapping.SetContext((IEnumerable<IViewBase>)MainProperty.GetValue(this));

                ViewReports = new ObservableCollection<ViewReport>
                    (Mapper.Map<IEnumerable<ReportView>, IEnumerable<ViewReport>>(Reports
                        .Where(x => x.engineerId == CurrentUser.Id)));
                ViewTasks = new ObservableCollection<ViewTask>
                    (Mapper.Map<IEnumerable<TaskView>, IEnumerable<ViewTask>>(Tasks));
                ViewProjects = new ObservableCollection<ViewProject>
                    (Mapper.Map<IEnumerable<ProjectView>, IEnumerable<ViewProject>>(Projects));

                var ViewProperty = this.GetType().GetProperty
                    ("View" + type.Name.Substring(0, type.Name.IndexOf("View")) + "s");

                var ShowingProperty = this.GetType().GetProperty
                    ("Showing" + type.Name.Substring(0, type.Name.IndexOf("View")) + "s");

                ShowingProperty.SetValue(this, ViewProperty.GetValue(this));
            });
        }

        #endregion

        #region Commands

        #region Tasks_Filter

        private Command _FilterTask;
        public ICommand FilterTask
        {
            get
            {
                if (_FilterTask != null)
                    return _FilterTask;
                _FilterTask = new Command(_FilterTask_Exec);
                return _FilterTask;
            }
        }

        private async void _FilterTask_Exec(object obj)
        {
            var project = obj as ViewProject;
            if(project != null)
            {
                var list = ViewTasks.Where(x => x.projectId == project.Id);
                ShowingTasks = new ObservableCollection<ViewTask>(list);
            }
            else
            {
                var str = obj as string;
                if(str == "All")
                {
                    ShowingTasks = ViewTasks;
                }
                if (str == "Download")
                {
                    await Download<TaskView>();
                }
            } 
        }

        #endregion

        #region Projects_Filter

        private Command _FilterProjects;
        public ICommand FilterProjects
        {
            get
            {
                if (_FilterProjects != null)
                    return _FilterProjects;
                _FilterProjects = new Command(_FilterProjects_Exec);
                return _FilterProjects;
            }
        }

        private async void _FilterProjects_Exec(object obj)
        {
            var controllers = obj as UIElementCollection;
            if (controllers == null)
            {
                var str = obj as string;
                if (str == "All")
                {
                    ShowingProjects = ViewProjects;
                }
                if (str == "Download")
                {
                    await Download<ProjectView>();
                }
                return;
            }

            var pickers = new List<DateTimePicker>();

            foreach (var item in controllers)
            {
                var picker = item as DateTimePicker;
                if (picker != null)
                    pickers.Add(picker);
            }

            var filters = new
            {
                start = pickers.Where(x => x.Name == "Filter_ProjectBegin").Single().Value,
                end = pickers.Where(x => x.Name == "Filter_ProjectEnd").Single().Value
            };

            ShowingProjects = ViewProjects;
            if(filters.start != null)
            {
                ShowingProjects = new ObservableCollection<ViewProject>
                    (ShowingProjects.Where(x => x.start > filters.start));
            }
            if(filters.end != null)
            {
                ShowingProjects = new ObservableCollection<ViewProject>
                    (ShowingProjects.Where(x => x.end < filters.end));
            }
        }

        #endregion

        #region Reports_Filter

        private Command _FilterReports;
        public ICommand FilterReports
        {
            get
            {
                if (_FilterReports != null)
                    return _FilterReports;
                _FilterReports = new Command(_FilterReports_Exec);
                return _FilterReports;
            }
        }

        private async void _FilterReports_Exec(object obj)
        {
            var controllers = obj as UIElementCollection;
            if(controllers == null)
            {
                var str = obj as string;
                if(str == "All")
                {
                    ShowingReports = ViewReports;
                }
                if(str == "Download")
                {
                    await Download<ReportView>();
                }
                return;
            }

            var comboBoxs = new List<ComboBox>();
            var pickers = new List<DateTimePicker>();

            foreach(var item in controllers)
            {
                var comboBox = item as ComboBox;
                var picker = item as DateTimePicker;
                if (comboBox != null)
                    comboBoxs.Add(comboBox);
                if (picker != null)
                    pickers.Add(picker);
            }

            var filters = new
            {
                task = comboBoxs.Where(x => x.Name == "Filter_Tasks").Single().SelectedItem,
                status = comboBoxs.Where(x => x.Name == "Filter_Status").Single().SelectedItem,
                activity = comboBoxs.Where(x => x.Name == "Filter_Activity").Single().SelectedItem,
                beginDate = pickers.Where(x => x.Name == "Filter_BeginTime").Single().Value,
                endDate = pickers.Where(x => x.Name == "Filter_EndTime").Single().Value
            };

            ShowingReports = ViewReports;
            if (filters.task != null)
            {
                ShowingReports = new ObservableCollection<ViewReport>
                    (ShowingReports.Where(x => x.taskId == ((ViewTask)filters.task).Id));
            }
            if (filters.status != null)
            {
                ShowingReports = new ObservableCollection<ViewReport>
                    (ShowingReports.Where(x => x.status == (ReportStatus)filters.status));
            }
            if (filters.activity != null)
            {
                ShowingReports = new ObservableCollection<ViewReport>
                    (ShowingReports.Where(x => x.activity == (ActivityType)filters.activity));
            }
            if (filters.beginDate != null)
            {
                ShowingReports = new ObservableCollection<ViewReport>
                    (ShowingReports.Where(x => x.start > filters.beginDate));
            }
            if (filters.endDate != null)
            {
                ShowingReports = new ObservableCollection<ViewReport>
                    (ShowingReports.Where(x => x.end < filters.endDate));
            }
        }

        #endregion

        #endregion

    }
}
