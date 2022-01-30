using Marketplace_v4.Models;

namespace Marketplace_v4.DataAccess
{
    public class ProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context; 
        }

        public List<Product> GetProducts() {
            return _context.Products.ToList<Product>();
        }





    }
}
