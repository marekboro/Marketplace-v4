using Newtonsoft.Json;
namespace Marketplace_v4.Models
{
    public class Product
    {
        [JsonProperty("productId")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string? Name {get; set; }
        [JsonProperty("Price")]
        public string? Price    { get; set; }

        public Product(int id, string name, string price)
        {
            this.Id = id;
            this.Name =  !String.IsNullOrEmpty(name) ? name : "";
            this.Price = !String.IsNullOrEmpty(price) ? price : "";
        }
        public Product() { }
    }
}
