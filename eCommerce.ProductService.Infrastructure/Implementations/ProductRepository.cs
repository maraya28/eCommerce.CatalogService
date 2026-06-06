using eCommerce.ProductService.Infrastructure.Contracts;
using eCommerce.ProductService.Infrastructure.Entities;
using eCommerce.ProductService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.ProductService.Infrastructure.Implementations
{
    public class ProductRepository(ProductDbContext dbContext) : IProductRepository
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
    }
}
