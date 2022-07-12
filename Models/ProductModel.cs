using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioDotNet.Models
{
    public class ProductModel
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}