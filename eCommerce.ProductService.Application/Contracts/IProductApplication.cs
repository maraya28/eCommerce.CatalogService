using eCommerce.ProductService.Application.Models;

namespace eCommerce.ProductService.Application.Contracts
{
    public interface IProductApplication
    {
        Task<IEnumerable<ProductResponse>> GetPagedAsync(int pageNumber = 1, int pageSize = 10);

        Task<ProductResponse> GetByIdAsync(string id);
    }
}
