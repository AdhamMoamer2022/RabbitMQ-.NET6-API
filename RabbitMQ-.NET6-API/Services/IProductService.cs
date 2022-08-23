using RabbitMQ_.NET6_API.Models;
using System.Collections;

namespace RabbitMQ_.NET6_API.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProductList();
        public Product GetProductById(int id);
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public bool DeleteProduct(int Id);
    }
}
