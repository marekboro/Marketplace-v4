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
    }
}




