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

        private bool _OperationResult;
        public bool OperationResult
        {
            get { return _OperationResult; }
            set
            {
                _OperationResult = value;
                OnPropertyChanged(nameof(OperationResult));
            }
        }

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

        #region Commands

        private Command _CRUD;
        public ICommand CRUD
        {
            get
            {
                if (_CRUD != null)
                    return _CRUD;
                _CRUD = new Command(_CRUD_Exec);
                return _CRUD;
            }
        }

        private Command _authorization;
        public ICommand Authorization
        {
            get
            {
                if (_authorization != null)
                    return _authorization;
                _authorization = new Command(_Authorization_Exec);
                return _authorization;
            }
        }

        #endregion
        
        #region Executes

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"> AuthorizationModel </param>
        private async void _Authorization_Exec(object obj)
        {
            IsAuthorized = false;

            var model = obj as AuthorizationModel;
            if(_client.Authorization(model.username, model.password))
            {
                IsAuthorized = true;
                Role = await _client.GetRoleAsync();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"> CRUDModel instance </param>
        private async void _CRUD_Exec(object obj)
        {
            OperationResult = false;
            var instance = (CRUDModel)obj;
            var funcName = "";
            switch (instance.operation)
            {
                case Operation.Post: funcName = nameof(_Add_Func); break;
                case Operation.Put: funcName = nameof(_Update_Func); break;
                case Operation.Delete: funcName = nameof(_Delete_Func); break;
                case Operation.Get: funcName = nameof(_GetAll_Func); break;
            }
            var generic = GetGenericMethod(funcName, instance.type);
            var task = (Task)generic.Invoke(this, new object[] { instance.model });
            await task;
        }

        #endregion

        #region Service

        private MethodInfo GetGenericMethod(string name, Type type)
        {
            var method = typeof(ApplicationView).GetRuntimeMethods().Where(x => x.Name == name).Single();
            return method.MakeGenericMethod(type);
        }

        private async Task _GetAll_Func<T>(object obj) where T : IViewBase
        {
            var list = await _client.GetAllAsync<T>();
            var collection = new ObservableCollection<T>(list);
            var type = typeof(T);
            var property = this.GetType().GetProperty(type.Name.Substring(0, type.Name.IndexOf("View")) + "s");
            property.SetValue(this, collection);
            OperationResult = true;
        }

        private async Task _Add_Func<T>(T view) where T : IViewBase
        {
            var result = await _client.AddAsync(view);
            OperationResult = result;
        }

        private async Task _Update_Func<T>(T view) where T : IViewBase
        {
            var result = await _client.UpdateAsync(view);
            OperationResult = result;
        }

        private async Task _Delete_Func<T>(T view) where T : IViewBase
        {
            var result = await _client.DeleteAsync<T>(view.GetId());
            OperationResult = result;
        }

        #endregion
    }
}
