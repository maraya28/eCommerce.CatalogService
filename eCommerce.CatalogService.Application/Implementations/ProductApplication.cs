using eCommerce.CatalogService.Application.Contracts;
using eCommerce.CatalogService.Application.Mappers;
using eCommerce.CatalogService.Application.Models;
using eCommerce.CatalogService.Domain.Models;
using eCommerce.CatalogService.Infrastructure.Contracts;
using eCommerce.CatalogService.Infrastructure.Entities;
using System.Text.Json;

namespace eCommerce.CatalogService.Application.Implementations
{
    public class ProductApplication(IProductRepository repository, IDistributedCache cache) : IProductApplication
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
            var cacheProduct = await cache.GetStringAsync(id);
            if (cacheProduct == null)
            {
                var productEntity = await repository.GetByIdAsync(id);

                await cache.SetStringAsync(id, JsonSerializer.Serialize(productEntity), TimeSpan.FromMinutes(5));

                var product = productEntity!.ToDomain();
                var productResponse = product.ToResponse();
                return productResponse;
            }

            var productEntityFromCache = JsonSerializer.Deserialize<ProductEntity>(cacheProduct);
            var productFromCache = productEntityFromCache!.ToDomain();
            var productResponseFromCache = productFromCache.ToResponse();
            return productResponseFromCache;
        }
    }
}
