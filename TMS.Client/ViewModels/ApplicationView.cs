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

namespace TMS.Client.ViewModels
{
    class ApplicationView:BaseView
    {
        private ProxyWebApi _client = new ProxyWebApi();

        public ApplicationView() { }

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

        #endregion
        
    }
}
