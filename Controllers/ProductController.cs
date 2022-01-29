using Microsoft.AspNetCore.Mvc;
using Marketplace_v4.Models;
using Marketplace_v4.DataAccess;
namespace Marketplace_v4.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        [HttpGet("products")]
        public IEnumerable<Product> GetAllProducts()
        {
            Data data = new Data();
            return data.GetProducts().ToArray();
        }

        [HttpGet("product/{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            Data data = new Data();
            return data.GetProduct(id);

        }

        [HttpPut("product/{id}")]

        public ActionResult<Product> UpdateProduct(int id, Product product)
        {
            Data data = new Data();
            Product toUpdate = data.GetProduct(id);
            // toUpdate.Name = product.Name;   
            //  toUpdate.Price = product.Price;
            toUpdate.Name = !String.IsNullOrEmpty(product.Name) ? product.Name : toUpdate.Name;
            toUpdate.Price = !String.IsNullOrEmpty(product.Price) ? product.Price : toUpdate.Price;

            return data.Update(id, toUpdate);

        }

        [HttpDelete("product/{id}")]

        public ActionResult DeleteProduct(int id)
        {
            Data data = new Data();
            data.Delete(id);
            return new EmptyResult();
        }
    }
}




