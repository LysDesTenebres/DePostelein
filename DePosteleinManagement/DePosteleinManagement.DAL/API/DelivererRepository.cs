using DePosteleinManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.DAL.API
{
    public class DelivererRepository : IDelivererRepository
    {
        private HttpClient _httpClient;
        string url = "api/deliverer/deliverers";

        private string _username = "";
        private string _password = "";

        public bool Delete(Deliverer t)
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

        public IList<Deliverer> GetAll()
        {
            var allDeliverers = new List<Deliverer>();

            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                allDeliverers = responseMessage.Content.ReadAsAsync<IEnumerable<Deliverer>>().Result as List<Deliverer>;
            }
            return allDeliverers;
        }

        public Deliverer GetById(int id)
        {
            Deliverer _deliverer= null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<Deliverer>>().Result as List<Deliverer>;
                _deliverer = result.Where(e => e.Id == id).FirstOrDefault();
            }
            return _deliverer;
        }

        public Deliverer Post(Deliverer t)
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

        public void Update(Deliverer t)
        {
            HttpResponseMessage responseMessage = _httpClient.PutAsJsonAsync(url + "/" + t.Id, t).Result;
        }
    }
}
