using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using TMS.Data;
using TMS.ViewModels;

namespace TMS.Services
{
    public class WebApiServices:IClient
    {
        private readonly string _app_path;
        private string _token;

        public bool IsAuthorizated
        {
            get { if (_token == null) return false; return true; }
        }

        public WebApiServices(string app_path = "http://localhost:58247")
        {
            _app_path = app_path;
        }

        //авторизація
        public bool Authorization(string username, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>( "grant_type", "password" ),
                    new KeyValuePair<string, string>( "username", username ),
                    new KeyValuePair<string, string> ( "Password", password )
                };
            var content = new FormUrlEncodedContent(pairs);

            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(_app_path + "/Token", content).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    // Десериализация полученного JSON-объекта
                    Dictionary<string, string> tokenDictionary = 
                        JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                    _token = tokenDictionary["access_token"];
                }
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        private HttpClient CreateClient()
        {
            if (_token == null)
                throw new Exception("You are not authorizated. Token is null");
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(_token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_app_path + "/");
            }
            return client;
        }

        //отримати роль користувача
        public Role GetRole()
        {
            using(var client = CreateClient())
            {
                var responce = client.GetAsync("/api/Account").Result;
                var roleStr = responce.Content.ReadAsAsync<string>().Result;
                return (Role)Enum.Parse(typeof(Role), roleStr);
            }
        }
        
        public async Task<Role> GetRoleAsync()
        {
            using (var client = CreateClient())
            {
                var responce = await client.GetAsync("/api/Account");
                var roleStr = responce.Content.ReadAsAsync<string>().Result;
                return (Role)Enum.Parse(typeof(Role), roleStr);
            }
        }

        public string Register(string email, string password, string login, string roleName, string firstname, string lastname, int teamId)
        {
            var registerModel = new
            {
                Email = email,
                Password = password,
                ConfirmPassword = password,
                Login = login,
                Role = roleName,
                firstName = firstname,
                lastName = lastname,
                team = teamId
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_app_path + '/');
                var response = client.PostAsJsonAsync("/api/Account/Register", registerModel).Result;
                return response.StatusCode.ToString();
            }
        }

        //CRUD операції
        #region CRUD

        public IEnumerable<Tview> GetAll<Tview>() where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return service.GetAll();
        }

        public async Task<IEnumerable<Tview>> GetAllAsync<Tview>() where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return await service.GetAllAsync();
        }

        public Tview Get<Tview>(int id) where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return service.Get(id);
        }

        public async Task<Tview> GetAsync<Tview>(int id) where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return await service.GetAsync(id);
        }

        public bool Add<Tview>(Tview model) where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return service.Add(model);
        }

        public async Task<bool> AddAsync<Tview>(Tview model) where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return await service.AddAsync(model);
        }

        public bool Update<Tview>(Tview model) where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return service.Update(model);
        }

        public async Task<bool> UpdateAsync<Tview>(Tview model) where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return await service.UpdateAsync(model);
        }

        public bool Delete<Tview>(int id) where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return service.Delete(id);
        }

        public async Task<bool> DeleteAsync<Tview>(int id) where Tview : IViewBase
        {
            var service = new Service<Tview>(CreateClient());
            return await service.DeleteAsync(id);
        }

        #endregion
    }
}
