using DePosteleinManagement.DAL.Repository;
using DePosteleinManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.DAL.API
{
    public class CustomerRepository : ICustomerRepository
    {
        private HttpClient _httpClient;
        string url = "api/menu/menua";

        private string _username = "";
        private string _password = "";

        public bool Delete(Customer t)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Post(Customer t)
        {
            throw new NotImplementedException();
        }

        public void SetCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
