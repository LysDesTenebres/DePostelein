using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DePosteleinManagement.Domain
{
    public class Event
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "guests")]
        public int Guests { get; set; }
        [JsonProperty(PropertyName = "bread")]
        public int Bread { get; set; }
        [JsonProperty(PropertyName = "menuId")]
        public int MenuId { get; set; }
        [JsonProperty(PropertyName = "customer")]
        public String Customer { get; set; }
        [JsonProperty(PropertyName = "location")]
        public String Location { get; set; }
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }
    }
}