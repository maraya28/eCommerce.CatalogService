using eCommerce.CatalogService.Application.Models;

namespace eCommerce.CatalogService.Application.Contracts
{
    public interface IProductApplication
    {
        Task<IEnumerable<ProductResponse>> GetPagedAsync(int pageNumber = 1, int pageSize = 10);

        Task<ProductResponse> GetByIdAsync(string id);
    }
}
