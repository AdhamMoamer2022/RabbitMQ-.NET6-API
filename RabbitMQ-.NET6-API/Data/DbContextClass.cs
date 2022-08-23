using Microsoft.EntityFrameworkCore;
using RabbitMQ_.NET6_API.Models;

namespace RabbitMQ_.NET6_API.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DbContextClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet <Product> Products { get; set; }
    }
}
