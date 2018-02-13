using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.Domain
{
    public class Customer
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "surname")]
        public String Surname { get; set; }
        [JsonProperty(PropertyName = "adress")]
        public String Adress { get; set; }
        [JsonProperty(PropertyName = "city")]
        public String City { get; set; }
        [JsonProperty(PropertyName = "postcode")]
        public int Postcode { get; set; }
    }
}
