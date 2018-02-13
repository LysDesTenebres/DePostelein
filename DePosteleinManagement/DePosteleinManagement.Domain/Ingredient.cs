using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DePosteleinManagement.Domain
{
    public class Ingredient
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }
        [JsonProperty(PropertyName = "unit")]
        public String Unit { get; set; }
        [JsonProperty(PropertyName = "dishId")]
        public int DishId { get; set; }
        [JsonProperty(PropertyName = "delivererId")]
        public int DelivererId { get; set; }
    }
}