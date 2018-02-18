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
    public class IngredientRepository : IIngredientRepository
    {
        private HttpClient _httpClient;
        string url = "api/ingredient/ingredients";

        private string _username = "";
        private string _password = "";

        public bool Delete(Ingredient t)
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

        public IList<Ingredient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ingredient GetById(int id)
        {
            Ingredient _ingredient = null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Ingredient>>().Result as List<Ingredient>;
                _ingredient = result.Where(e => e.Id == id).FirstOrDefault();
            }
            return _ingredient;
        }

        public List<Ingredient> GetIngredientsByDishId(int id)
        {
            List<Ingredient> ingredients = null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Ingredient>>().Result as List<Ingredient>;
                ingredients = result.Where(e => e.DishId == id).ToList();
            }
            return ingredients;
        }

        public Ingredient Post(Ingredient t)
        {
            HttpResponseMessage responseMessage = _httpClient.PostAsJsonAsync(url, t).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return t;
            }
            else
                return null;
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

        public void Update(Ingredient t)
        {
            HttpResponseMessage responseMessage = _httpClient.PutAsJsonAsync(url + "/" + t.Id, t).Result;
        }
    }
}
