using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DePosteleinManagement.DAL.Repository;
using DePosteleinManagement.Domain;

namespace DePosteleinManagement.DAL.API
{
    public class DishRepository : IDishRepository
    {
        private HttpClient _httpClient;
        string url = "api/dish/dishes";

        private string _username = "";
        private string _password = "";

        public bool Delete(Dish t)
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

        public IList<Dish> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dish GetById(int id)
        {
            Dish _dish = null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Dish>>().Result as List<Dish>;
                _dish = result.Where(e => e.Id == id).FirstOrDefault();
            }
            return _dish;
        }

        public Dish Post(Dish t)
        {
            Dish result = null;
            HttpResponseMessage responseMessage = _httpClient.PostAsJsonAsync(url, t).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsAsync<Dish>().Result;
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
                BaseAddress = new Uri("http://localhost:8910/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public void Update(Dish t)
        {
            HttpResponseMessage responseMessage = _httpClient.PutAsJsonAsync(url + "/" + t.Id, t).Result;
        }

        public IList<Dish> GetDishesByMenuId(int id)
        {
            string dishesByMenu = url + "/menu/" + id;
            List<Dish> dishes = null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Dish>>().Result as List<Dish>;
                dishes = result.Where(c => c.MenuId == id).ToList();
            }
            return dishes;
        }

        public IList<Dish> GetDishesByFunctionId(String id)
        {
            List<Dish> dishes = null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Dish>>().Result as List<Dish>;
                dishes = result.Where(c => c.role == id).ToList();
            }
            return dishes;
        }
    }
}
