using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TMS.ViewModels;

namespace TMS.Services
{
    class Service<Tview> where Tview : IViewBase
    {
        private HttpClient _client;
        private readonly string _typeName;

        public Service(HttpClient client)
        {
            _client = client;
            var type = typeof(Tview);
            _typeName = type.Name.Substring(0, type.Name.IndexOf("View")) + "s";
        }

        public IEnumerable<Tview> GetAll()
        {
            HttpResponseMessage response = _client.GetAsync("api/" + _typeName).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<IEnumerable<Tview>>().Result;
                return result;
            }
            throw new Exception();
        }

        public Tview Get(int id)
        {
            HttpResponseMessage response = _client.GetAsync("api/" + _typeName + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Tview>().Result;
                return result;
            }
            throw new Exception();
        }

        public bool Add(Tview model)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("api/" + _typeName, model).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(result))
                    return true;
                else return false;
            }
            throw new Exception("Add new model is fucked");
        }

        public bool Update(Tview model)
        {
            HttpResponseMessage response = _client.PutAsJsonAsync("api/" + _typeName, model).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(result))
                    return true;
                else return false;
            }
            throw new Exception("Update model is fucked");
        }

        public bool Delete(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync("api/" + _typeName + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(result))
                    return true;
                else return false;
            }
            throw new Exception("Delete model is fucked");
        }

        
    }
}
