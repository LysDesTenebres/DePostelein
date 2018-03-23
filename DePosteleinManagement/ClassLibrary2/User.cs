using ClassLibrary2.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.Domain
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "salt")]
        public string Salt { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }
        [JsonProperty(PropertyName = "role")]
        public string Function { get; set; }
        [JsonProperty(PropertyName = "help")]
        public string UserRoleHelp { get; set; }
        [JsonProperty(PropertyName = "userRole")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole UserRole { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string EMail { get; set; }
    }
}
