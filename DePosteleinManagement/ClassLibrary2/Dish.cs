using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.Domain
{
    public class Dish
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "menuId")]
        public int MenuId { get; set; }
        [JsonProperty(PropertyName = "role")]
        public String role { get; set; }
    }
}
