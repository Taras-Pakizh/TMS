using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TMS.Services
{
    public class WebApiServices
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

        // получение токена
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

        // создаем http-клиента с токеном 
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

        // получаем информацию о клиенте 
        public string GetUserInfo()
        {
            using (var client = CreateClient())
            {
                var response = client.GetAsync("/api/Account/UserInfo").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        // обращаемся по маршруту api/values 
        public string GetValues()
        {
            using (var client = CreateClient())
            {
                var response = client.GetAsync("/api/values").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        // регистрация
        public string Register(string email, string password)
        {
            var registerModel = new
            {
                Email = email,
                Password = password,
                ConfirmPassword = password
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync("/api/Account/Register", registerModel).Result;
                return response.StatusCode.ToString();
            }
        }
        
        public IEnumerable<T> GetAll<T>() where T : class
        {
            var service = new Service<T>(CreateClient());
            return service.GetAll();
        }

        public T Get<T>(int id) where T : class
        {
            var service = new Service<T>(CreateClient());
            return service.Get(id);
        }

        public bool Add<T>(T model) where T : class
        {
            var service = new Service<T>(CreateClient());
            return service.Add(model);
        }

        public bool Update<T>(T model) where T : class
        {
            var service = new Service<T>(CreateClient());
            return service.Update(model);
        }

        public bool Delete<T>(int id) where T : class
        {
            var service = new Service<T>(CreateClient());
            return service.Delete(id);
        }
    }
}
