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
        string url = "api/menu/menua";

        private string _username = "";
        private string _password = "";

        public MenuRepository()
        {

        }

        public bool Delete(Menu t)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Menu Post(Menu t)
        {
            throw new NotImplementedException();
        }

        public void SetCredentials(string username, string password)
        {
            _username = username;
            _password = password;
            var _credentials = new NetworkCredential(_username, _password);
            HttpClientHandler _handler = new HttpClientHandler { Credentials = _credentials };
            _httpClient = new HttpClient(_handler)
            {
                BaseAddress = new Uri("http://167.114.17.246:8080/api")
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public void Update(Menu t)
        {
            throw new NotImplementedException();
        }
    }
}
