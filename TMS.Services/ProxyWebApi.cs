using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;
using TMS.ViewModels;

namespace TMS.Services
{
    public class ProxyWebApi : IClient
    {
        #region Proxy

        public WebApiServices Client { get; private set; }

        private Dictionary<Type, IEnumerable<IViewBase>> _LoadedData = new Dictionary<Type, IEnumerable<IViewBase>>();

        private Dictionary<Type, bool> _isActual_list = new Dictionary<Type, bool>();

        private UserView _currentUser;

        private bool _isUserActual { get; set; }



        public ProxyWebApi()
        {
            Client = new WebApiServices();
        }

        public ProxyWebApi(string app_path)
        {
            Client = new WebApiServices(app_path);
        }

        private void _AddSet<T>(IEnumerable<T> list) where T : IViewBase
        {
            if(_LoadedData.Keys.Contains(typeof(T)))
            {
                _LoadedData[typeof(T)] = (IEnumerable<IViewBase>) list;
                _isActual_list[typeof(T)] = true;
                return;
            }
            _LoadedData.Add(typeof(T), (IEnumerable<IViewBase>)list);
            _isActual_list.Add(typeof(T), true);
        }

        private IEnumerable<T> _GetLoadedData<T>()
        {
            return (IEnumerable<T>)_LoadedData[typeof(T)];
        }

        public bool IsActual(Type type)
        {
            if (_isActual_list.Keys.Contains(type))
            {
                return _isActual_list[type];
            }
            return false;
        }

        private void _UpdateSet(Type type, bool value)
        {
            if (_isActual_list.Keys.Contains(type))
            {
                _isActual_list[type] = value;
            }
        }

        #endregion

        #region Interface

        public bool IsAuthorizated
        {
            get { return Client.IsAuthorizated; }
        }

        public bool Add<Tview>(Tview model) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return Client.Add(model);
        }

        public async Task<bool> AddAsync<Tview>(Tview model) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return await Client.AddAsync(model);
        }

        public bool Authorization(string username, string password)
        {
            _isUserActual = false;
            return Client.Authorization(username, password);
        }

        public bool Delete<Tview>(int id) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return Client.Delete<Tview>(id);
        }

        public async Task<bool> DeleteAsync<Tview>(int id) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return await Client.DeleteAsync<Tview>(id);
        }

        public Tview Get<Tview>(int id) where Tview : IViewBase
        {
            return Client.Get<Tview>(id);
        }

        public IEnumerable<Tview> GetAll<Tview>() where Tview : IViewBase
        {
            if (IsActual(typeof(Tview)))
            {
                return _GetLoadedData<Tview>();
            }
            var result = Client.GetAll<Tview>();
            _AddSet(result);
            return result;
        }

        public async Task<IEnumerable<Tview>> GetAllAsync<Tview>() where Tview : IViewBase
        {
            if (IsActual(typeof(Tview)))
            {
                return _GetLoadedData<Tview>();
            }
            var result = await Client.GetAllAsync<Tview>();
            _AddSet(result);
            return result;
        }

        public async Task<Tview> GetAsync<Tview>(int id) where Tview : IViewBase
        {
            return await Client.GetAsync<Tview>(id);
        }

        public Role GetRole()
        {
            return Client.GetRole();
        }

        public async Task<Role> GetRoleAsync()
        {
            return await Client.GetRoleAsync();
        }

        public string Register(string email, string password, string login, string roleName, string firstname, string lastname, int teamId)
        {
            return Client.Register(email, password, login, roleName, firstname, lastname, teamId);
        }

        public bool Update<Tview>(Tview model) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return Client.Update(model);
        }

        public async Task<bool> UpdateAsync<Tview>(Tview model) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return await Client.UpdateAsync(model);
        }

        public async Task<UserView> GetCurrentUser(string login)
        {
            if (_isUserActual)
            {
                return _currentUser;
            }
            _currentUser = await Client.GetCurrentUser(login);
            _isUserActual = true;
            return _currentUser;
        }

        #endregion
    }
}
