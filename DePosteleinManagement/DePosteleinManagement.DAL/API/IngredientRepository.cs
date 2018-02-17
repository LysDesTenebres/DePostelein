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
    public class IngredientRepository : IIngredientRepository
    {
        private HttpClient _httpClient;
        string url = "api/menu/menua";

        private string _username = "";
        private string _password = "";

        public bool Delete(Ingredient t)
        {
            throw new NotImplementedException();
        }

        public IList<Ingredient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ingredient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ingredient> GetIngredientsByDishId(int id)
        {
            throw new NotImplementedException();
        }

        public Ingredient Post(Ingredient t)
        {
            throw new NotImplementedException();
        }

        public void SetCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(Ingredient t)
        {
            throw new NotImplementedException();
        }
    }
}
