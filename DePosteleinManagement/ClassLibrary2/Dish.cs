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
    public class Dish
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "menuId")]
        public int MenuId { get; set; }
        [JsonProperty(PropertyName = "role")]
        public string role { get; set; }
        [JsonProperty(PropertyName = "kitchenRole")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole KitchenRole { get; set; }
    }
}
