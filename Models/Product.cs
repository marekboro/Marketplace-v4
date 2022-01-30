
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace_v4.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
       
        public string? Name {get; set; }
      
        public string? Price { get; set; }

        public Product() { } // required for instantiationg a product without ID. used by productRepo Create
    }
}
