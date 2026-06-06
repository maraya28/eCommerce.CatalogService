using eCommerce.ProductService.Application.Contracts;
using eCommerce.ProductService.Application.Models;
using eCommerce.ProductService.Application.Mappers;
using eCommerce.ProductService.Infrastructure.Contracts;

namespace eCommerce.ProductService.Application.Implementations
{
    public class ProductApplication(IProductRepository repository) : IProductApplication
    {
        public async Task<IEnumerable<ProductResponse>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var productEntities = await repository.GetPagedAsync(pageNumber, pageSize);
            var products = productEntities.ToDomain();
            var productsReponse = products.ToResponse();
            return productsReponse;
        }

        public async Task<ProductResponse> GetByIdAsync(string id)
        {
            var productEntity = await repository.GetByIdAsync(id);
            var product = productEntity!.ToDomain();
            var productResponse = product.ToResponse();
            return productResponse;
        }
    }
}
