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
    public class EventRepository : IEventRepository
    {
        private HttpClient _httpClient;
        string url = "api/menu/menua";

        private string _username = "";
        private string _password = "";

        public bool Delete(Event t)
        {
            throw new NotImplementedException();
        }

        public IList<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public Event GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Event Post(Event t)
        {
            throw new NotImplementedException();
        }

        public void SetCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(Event t)
        {
            throw new NotImplementedException();
        }
    }
}
