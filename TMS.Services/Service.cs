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

        private T ReadAs<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<T>().Result;
                return result;
            }
            throw new Exception("Read as is fucked " + typeof(T) + " = " + response.StatusCode);
        }

        private bool ReadAsString(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(result))
                    return true;
                else return false;
            }
            throw new Exception("Read as string is fucked");
        }

        #region Govno

        public Tview AddNEW(Tview model)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("api/" + _typeName, model).Result;
            var i = ReadAs<Tview>(response);
            return i;
        }

        #endregion

        public IEnumerable<Tview> GetAll()
        {
            HttpResponseMessage response = _client.GetAsync("api/" + _typeName).Result;
            return ReadAs<IEnumerable<Tview>>(response);
        }

        public async Task<IEnumerable<Tview>> GetAllAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("api/" + _typeName);
            return ReadAs<IEnumerable<Tview>>(response);
        }

        public Tview Get(int id)
        {
            HttpResponseMessage response = _client.GetAsync("api/" + _typeName + "/" + id).Result;
            return ReadAs<Tview>(response);
        }

        public async Task<Tview> GetAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync("api/" + _typeName + "/" + id);
            return ReadAs<Tview>(response);
        }

        public bool Add(Tview model)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("api/" + _typeName, model).Result;
            return ReadAsString(response);
        }

        public async Task<bool> AddAsync(Tview model)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/" + _typeName, model);
            return ReadAsString(response);
        }

        public bool Update(Tview model)
        {
            HttpResponseMessage response = _client.PutAsJsonAsync("api/" + _typeName, model).Result;
            return ReadAsString(response);
        }

        public async Task<bool> UpdateAsync(Tview model)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync("api/" + _typeName, model);
            return ReadAsString(response);
        }

        public bool Delete(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync("api/" + _typeName + "/" + id).Result;
            return ReadAsString(response);
        }

        public  async Task<bool> DeleteAsync(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync("api/" + _typeName + "/" + id);
            return ReadAsString(response);
        }
    }
}
