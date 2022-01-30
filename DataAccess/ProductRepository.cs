using Marketplace_v4.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Product?> GetProduct(int id) {
            return await _context.Products.FindAsync(id);   
        }

        public async Task<Product> UpdateProduct( Product updatedProduct) {
            var  productAtId = await GetProduct(updatedProduct.id)!; 
            productAtId.Name = !string.IsNullOrEmpty(updatedProduct.Name)? updatedProduct.Name : productAtId.Name;
            productAtId.Price = !string.IsNullOrEmpty(updatedProduct.Price)? updatedProduct.Price : productAtId.Price;

            await _context.SaveChangesAsync();
            return productAtId;
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<Product> AddProduct(NewProductRequest product) {
            var newProduct = new Product() {Name = product.Name,Price = product.Price };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return newProduct;
        }
    }
}
