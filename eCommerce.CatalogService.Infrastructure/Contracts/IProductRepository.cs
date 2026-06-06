using eCommerce.CatalogService.Infrastructure.Entities;

namespace eCommerce.CatalogService.Infrastructure.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetPagedAsync(int pageNumber, int pageSize);

        Task<ProductEntity?> GetByIdAsync(string id);

        Task AddAsync(ProductEntity productEntity);
    }
}
