using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DePosteleinManagement.DAL.Repository;
using DePosteleinManagement.Domain;
using Newtonsoft.Json;

namespace DePosteleinManagement.DAL.API
{
    public class UserRepository : IUserRepository
    {
        private HttpClient _httpClient;
        string url = "api/user/users";

        private string _username = "";
        private string _password = "";

        public bool Delete(User t)
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

        public IList<User> GetAll()
        {
            var allUsers = new List<User>();

            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsAsync<IEnumerable<User>>().Result as List<User>;
                var txtBlock = responseMessage.Content.ReadAsStringAsync().Result; //right!
                //allUsers = JsonConvert.DeserializeObject<List<User>>(txtBlock);
                allUsers = result;
            }
            return allUsers;
        }

        public User GetById(int id)
        {
            User user = null;
            HttpResponseMessage responseMessage = _httpClient.GetAsync(url).Result;

            if (responseMessage.IsSuccessStatusCode)
            {

                var result = responseMessage.Content.ReadAsAsync<IEnumerable<User>>().Result as List<User>;
                user = result.Where(u => u.Id == id).FirstOrDefault();
            }
            return user;
        }

        public User Post(User t)
        {
            User result = null;
            HttpResponseMessage responseMessage = _httpClient.PostAsJsonAsync(url, t).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsAsync<User>().Result;
                
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

            public void Update(User t)
        {
            HttpResponseMessage responseMessage = _httpClient.PutAsJsonAsync(url + "/" + t.Id, t).Result;
        }
    }
}
