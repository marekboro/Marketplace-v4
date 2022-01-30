using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace_v4.Models
{
    public class Product
    {
        [JsonProperty("productId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [JsonProperty("Name")]
        public string? Name {get; set; }
        [JsonProperty("Price")]
        public string? Price { get; set; }

        public Product(int id, string name, string price)
        {
            this.id = id;
            Name =  !string.IsNullOrEmpty(name) ? name : "";
            Price = !string.IsNullOrEmpty(price) ? price : "";
        }





        public Product() { } // required for instantiating with sql queries. 
    }
}
