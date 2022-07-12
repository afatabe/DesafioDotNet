using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioDotNet.Models
{
    public class RequestProduct
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }

    }
}