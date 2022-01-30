using Microsoft.AspNetCore.Mvc;
using Marketplace_v4.Models;
using Marketplace_v4.DataAccess;
namespace Marketplace_v4.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
       private readonly Data _data;
        public ProductController(Data data) {
            _data = data;
        }

        [HttpGet("products")]
        public IEnumerable<Product> GetAllProducts()
        {
            //Data data = new Data();
            return _data.GetProducts().ToArray();
        }

        [HttpGet("product/{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            //Data data = new Data();
            var product = _data.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;

        }

        [HttpPut("product/{id}")]

        public ActionResult<Product> UpdateProduct(int id, [FromForm] Product product)
        {
            // Data data = new Data();
            var toUpdate = _data.GetProduct(id);
            if (toUpdate == null)
            {
                return NotFound();
            }

            toUpdate.Name = !String.IsNullOrEmpty(product.Name) ? product.Name : toUpdate.Name;
            toUpdate.Price = !String.IsNullOrEmpty(product.Price) ? product.Price : toUpdate.Price;

            return _data.Update(id, toUpdate);

        }



        [HttpDelete("product/{id}")]

        public ActionResult DeleteProduct(int id)
        {
            //  Data data = new Data();
            var toDelete = _data.GetProduct(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _data.Delete(id);
            return new EmptyResult();
        }

        [HttpPost("product")]
        public Product CreateProduct([FromForm]Product product)
        {
            //Data data = new Data();

            var productAddedId = _data.AddProduct(product);
            var returned = _data.GetProduct(productAddedId);
            return returned;
        }


    }
}




