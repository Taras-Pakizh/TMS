using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Services
{
    class Service<T> where T : class
    {
        private HttpClient _client;
        private readonly string _typeName;

        public Service(HttpClient client)
        {
            _client = client;
            var type = typeof(T);
            _typeName = type.Name;
        }

        public IEnumerable<T> GetAll()
        {
            HttpResponseMessage response = _client.GetAsync("api/" + _typeName).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                return result;
            }
            throw new Exception();
        }

        public T Get(int id)
        {
            HttpResponseMessage response = _client.GetAsync("api/" + _typeName + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<T>().Result;
                return result;
            }
            throw new Exception();
        }

        public bool Add(T model)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("api/" + _typeName, model).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<bool>().Result;
                return result;
            }
            throw new Exception("Add new model is fucked");
        }

        public bool Update(T model)
        {
            HttpResponseMessage response = _client.PutAsJsonAsync("api/" + _typeName, model).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<bool>().Result;
                return result;
            }
            throw new Exception("Update model is fucked");
        }

        public bool Delete(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync("api/" + _typeName + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<bool>().Result;
                return result;
            }
            throw new Exception("Delete model is fucked");
        }

        
    }
}
