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
    public class EventRepository : IEventRepository
    {
        private HttpClient _httpClient;
        string url = "api/event/events";

        private string _username = "";
        private string _password = "";

        public bool Delete(Event t)
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

        public IList<Event> GetAll()
        {
            var allEvents = new List<Event>();

            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                allEvents = responseMessage.Content.ReadAsAsync<IEnumerable<Event>>().Result as List<Event>;
            }
            return allEvents;
        }

        public Event GetById(int id)
        {
            Event _event = null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Event>>().Result as List<Event>;
                _event = result.Where(e => e.Id == id).FirstOrDefault();
            }
            return _event;
        }

        public Event Post(Event t)
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

        public void Update(Event t)
        {
            HttpResponseMessage responseMessage = _httpClient.PutAsJsonAsync(url + "/" + t.Id, t).Result;
        }
    }
}
