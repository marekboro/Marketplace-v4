using Newtonsoft.Json;
namespace Marketplace_v4.Models
{
    public class Product
    {
        [JsonProperty("productId")]
        public int productId { get; set; }
        [JsonProperty("Name")]
        public string? Name {get; set; }
        [JsonProperty("Price")]
        public string? Price { get; set; }

        public Product(int id, string name, string price)
        {
            productId = id;
            Name =  !string.IsNullOrEmpty(name) ? name : "";
            Price = !string.IsNullOrEmpty(price) ? price : "";
        }
        public Product() { } // required for instantiating with sql queries. 
    }
}
