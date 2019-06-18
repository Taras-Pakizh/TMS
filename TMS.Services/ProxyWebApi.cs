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

        private WebApiServices _client;

        private List<IEnumerable<IViewBase>> _LoadedData = new List<IEnumerable<IViewBase>>();

        private Dictionary<Type, bool> _isActual_list = new Dictionary<Type, bool>();

        public ProxyWebApi()
        {
            _client = new WebApiServices();
        }

        public ProxyWebApi(string app_path)
        {
            _client = new WebApiServices(app_path);
        }

        private void _AddSet<T>(IEnumerable<T> list) where T : IViewBase
        {
            if(_LoadedData.Exists(x=>x.GetType() == list.GetType()))
            {
                var prevList = _LoadedData.Where(x => x.GetType() == list.GetType()).Single();
                _LoadedData.Remove(prevList);
            }
            _LoadedData.Add((IEnumerable<IViewBase>)list);
            _isActual_list.Add(typeof(T), true);
        }

        private bool _IsActual(Type type)
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
            get { return _client.IsAuthorizated; }
        }

        public bool Add<Tview>(Tview model) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return _client.Add(model);
        }

        public async Task<bool> AddAsync<Tview>(Tview model) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return await _client.AddAsync(model);
        }

        public bool Authorization(string username, string password)
        {
            return _client.Authorization(username, password);
        }

        public bool Delete<Tview>(int id) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return _client.Delete<Tview>(id);
        }

        public async Task<bool> DeleteAsync<Tview>(int id) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return await _client.DeleteAsync<Tview>(id);
        }

        public Tview Get<Tview>(int id) where Tview : IViewBase
        {
            return _client.Get<Tview>(id);
        }

        public IEnumerable<Tview> GetAll<Tview>() where Tview : IViewBase
        {
            var result = _client.GetAll<Tview>();
            _AddSet(result);
            return result;
        }

        public async Task<IEnumerable<Tview>> GetAllAsync<Tview>() where Tview : IViewBase
        {
            var result = await _client.GetAllAsync<Tview>();
            _AddSet(result);
            return result;
        }

        public async Task<Tview> GetAsync<Tview>(int id) where Tview : IViewBase
        {
            return await _client.GetAsync<Tview>(id);
        }

        public Role GetRole()
        {
            return _client.GetRole();
        }

        public async Task<Role> GetRoleAsync()
        {
            return await _client.GetRoleAsync();
        }

        public string Register(string email, string password, string login, string roleName, string firstname, string lastname, int teamId)
        {
            return _client.Register(email, password, login, roleName, firstname, lastname, teamId);
        }

        public bool Update<Tview>(Tview model) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return _client.Update(model);
        }

        public async Task<bool> UpdateAsync<Tview>(Tview model) where Tview : IViewBase
        {
            _UpdateSet(typeof(Tview), false);
            return await _client.UpdateAsync(model);
        }

        #endregion
    }
}
