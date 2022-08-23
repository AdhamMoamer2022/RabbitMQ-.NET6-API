
using Microsoft.AspNetCore.Mvc;
using RabbitMQ_.NET6_API.Models;
using RabbitMQ_.NET6_API.RabbitMQ;
using RabbitMQ_.NET6_API.Services;

namespace RabbitMQ_.NET6_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRabitMQProducer _rabitMQProducer;

        public ProductController(IProductService productService, IRabitMQProducer rabitMQProducer)
        {
            _productService = productService;
            _rabitMQProducer = rabitMQProducer;
        }
        [HttpGet("productlist")]
        public IEnumerable<Product> GetProductList()
        {
            return _productService.GetProductList();


        }
        [HttpGet("getproductbyid")]
        public Product GetProductById(int id)
        {
            return _productService.GetProductById(id);

        }
        [HttpPost("addProduct")]
        public Product AddProduct(Product product)
        {
            var addedProdcut = _productService.AddProduct(product);
            _rabitMQProducer.SendProductMessage(addedProdcut);
            return addedProdcut;


        }
        [HttpPut("updateproduct")]
        public Product UpdateProduct(Product product)
        {
            return _productService.UpdateProduct(product);
        }
        [HttpDelete("deleteproduct")]
        public bool DeleteProduct(int Id)
        {
            return _productService.DeleteProduct(Id);
        }

    }
}
