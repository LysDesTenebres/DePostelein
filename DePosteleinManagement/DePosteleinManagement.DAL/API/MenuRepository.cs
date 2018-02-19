using DePosteleinManagement.DAL.Repository;
using DePosteleinManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.DAL.API
{
    public class MenuRepository : IMenuRepository
    {
        private HttpClient _httpClient;
        string url = "api/menu/menus";

        private string _username = "";
        private string _password = "";

        public MenuRepository()
        {

        }

        public bool Delete(Menu t)
        {
            string deleteUrl = url + "/" + t.Id;

            HttpResponseMessage responseMessage = _httpClient.DeleteAsync(deleteUrl).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
                return false;
        }

        public IList<Menu> GetAll()
        {
            var allMenus = new List<Menu>();

            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Menu>>().Result as List<Menu>;
                allMenus = result;
            }
            return allMenus;
        }

        public Menu GetById(int id)
        {
            Menu _menu = null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Menu>>().Result as List<Menu>;
                _menu = result.Where(e => e.Id == id).FirstOrDefault();
            }
            return _menu;
        }

        public Menu Post(Menu t)
        {
            Menu result = null;
            HttpResponseMessage responseMessage = _httpClient.PostAsJsonAsync(url, t).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsAsync<Menu>().Result;
                //result = resultHttp.FirstOrDefault();
            }
            return result;
        }


        public void SetCredentials(string username, string password)
        {
            _username = username;
            _password = password;
            var _credentials = new NetworkCredential(_username, _password);
            HttpClientHandler _handler = new HttpClientHandler { Credentials = _credentials };
            _httpClient = new HttpClient(_handler)
            {
                BaseAddress = new Uri("http://localhost:8910")
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public void Update(Menu t)
        {
            HttpResponseMessage responseMessage = _httpClient.PutAsJsonAsync(url + "/" + t.Id, t).Result;
        }
    }
}
