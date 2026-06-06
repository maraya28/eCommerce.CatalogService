using eCommerce.CatalogService.Infrastructure.Contracts;
using eCommerce.CatalogService.Infrastructure.Entities;
using eCommerce.CatalogService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerce.CatalogService.Infrastructure.Implementations
{
    public class ProductRepository(ProductDbContext dbContext, ILogger<ProductRepository> logger) : IProductRepository
    {
        public async Task<IEnumerable<ProductEntity>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await dbContext.Products
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ProductEntity?> GetByIdAsync(string id)
        {
            return await dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(ProductEntity productEntity)
        {
            dbContext.Products.Add(productEntity);
            await dbContext.SaveChangesAsync();
        }
    }
}
