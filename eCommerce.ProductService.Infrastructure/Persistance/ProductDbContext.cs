using eCommerce.ProductService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.ProductService.Infrastructure.Persistance
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
