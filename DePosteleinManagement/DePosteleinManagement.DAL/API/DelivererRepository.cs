using DePosteleinManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.DAL.API
{
    public class DelivererRepository : IDelivererRepository
    {
        private HttpClient _httpClient;
        string url = "api/menu/menua";

        private string _username = "";
        private string _password = "";

        public bool Delete(Deliverer t)
        {
            throw new NotImplementedException();
        }

        public IList<Deliverer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Deliverer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Deliverer Post(Deliverer t)
        {
            throw new NotImplementedException();
        }

        public void SetCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(Deliverer t)
        {
            throw new NotImplementedException();
        }
    }
}
