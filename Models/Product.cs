namespace Marketplace_v4.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name {get; set; }

        public string Price    { get; set; }

        public Product(int id, string name, string price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
    }
}
