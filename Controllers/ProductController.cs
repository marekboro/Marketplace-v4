using Microsoft.AspNetCore.Mvc;
using Marketplace_v4.Models;
using Marketplace_v4.DataAccess;
namespace Marketplace_v4.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
                {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public ProductController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetProductController")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet("products")]
        public IEnumerable<Product> GetAllProducts() {

            //return Enumerable.Range(1, 5).Select(index => new Product
            //(
            //     Random.Shared.Next(-20, 55),
            //    $"Name{Random.Shared.Next(-20, 55)}",
            //   Random.Shared.Next(-20, 55)

            //))
            //.ToArray();

            Data data = new Data();
            return data.GetProducts().ToArray();

        }
    }
}




