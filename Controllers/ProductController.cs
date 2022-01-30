using Microsoft.AspNetCore.Mvc;
using Marketplace_v4.Models;
using Marketplace_v4.DataAccess;
namespace Marketplace_v4.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repository;
       // private readonly Data _data;

        public ProductController(
           // Data data, 
            ProductRepository repository)
        {
           // _data = data;
            _repository = repository;
        }

        [HttpGet("products")]
        public IEnumerable<Product> GetAllProducts()
        {
            //return _data.GetProducts().ToArray();
            return _repository.GetProducts();//.ToArray();
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            //var product = _data.GetProduct(id);
            var product = await _repository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPut("product/{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromForm] NewProductRequest product)
        {
            //var toUpdate = _data.GetProduct(id);
            var toUpdate = await _repository.GetProduct(id);
            if (toUpdate == null)
            {
                return NotFound();
            }

            toUpdate.Name = !string.IsNullOrEmpty(product.Name) ? product.Name : toUpdate.Name;
            toUpdate.Price = !string.IsNullOrEmpty(product.Price) ? product.Price : toUpdate.Price;
           // return _data.Update(toUpdate);
            return await _repository.UpdateProduct(toUpdate);
        }

        [HttpDelete("product/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            //var toDelete = _data.GetProduct(id);
            var toDelete = await _repository.GetProduct(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            //_data.Delete(id);
              _repository.DeleteProduct(toDelete);
            return Ok();//new EmptyResult();
        }

        [HttpPost("product")]
        public async Task<Product> CreateProduct([FromForm] NewProductRequest product)
        {

            //var productAddedId = _data.AddProduct(product);
            //var returned = _data.GetProduct(productAddedId);
            var productAdded = await _repository.AddProduct(product);
            //var returned = _repository.GetProduct(productAddedId);
            return productAdded;
        }
    }
}




