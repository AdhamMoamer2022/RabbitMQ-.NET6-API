﻿using RabbitMQ_.NET6_API.Data;
using RabbitMQ_.NET6_API.Models;

namespace RabbitMQ_.NET6_API.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;
        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int Id)
        {
            var deletedProduct = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _dbContext.Products.Remove(deletedProduct);
            return result != null ? true : false;
           
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
