namespace Marketplace_v4.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price    { get; set; }

        public Product(int id, string name, int price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
     }
}
