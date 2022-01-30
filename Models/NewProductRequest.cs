using Newtonsoft.Json;
namespace Marketplace_v4.Models
{
    public class NewProductRequest
    {
       
      //  [JsonProperty("Name")]
        public string? Name { get; set; }
       // [JsonProperty("Price")]
        public string? Price { get; set; }

        //public NewProductRequest(int id, string name, string price)
        //{
            
        //    Name = !string.IsNullOrEmpty(name) ? name : "";
        //    Price = !string.IsNullOrEmpty(price) ? price : "";
        //}

    }
}
