using System;
using System.Collections.Generic;
using System.Linq;
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
        string url = "api/menu/menua";

        private string _username = "";
        private string _password = "";

        public bool Delete(Dish t)
        {
            throw new NotImplementedException();
        }

        public IList<Dish> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dish GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Dish Post(Dish t)
        {
            throw new NotImplementedException();
        }

        public void SetCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(Dish t)
        {
            throw new NotImplementedException();
        }

        public IList<Dish> GetDishesByMenuId(int id)
        {
            List<Dish> dishes = null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Dish>>().Result as List<Dish>;
                dishes = result.Where(c => c.MenuId == id).ToList();
            }
            return dishes;
        }
    }
}
