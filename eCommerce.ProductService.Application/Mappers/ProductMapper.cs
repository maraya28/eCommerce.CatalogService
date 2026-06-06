using eCommerce.ProductService.Application.Models;
using eCommerce.ProductService.Domain.Models;
using eCommerce.ProductService.Infrastructure.Entities;

namespace eCommerce.ProductService.Application.Mappers
{
    public static class ProductMapper
    {
        public static Product ToDomain(this ProductEntity product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
            };
        }

        public static IEnumerable<Product> ToDomain(this IEnumerable<ProductEntity> products)
        {
            List<Product> productsDomain = [];

            foreach (var product in products)
            {
                productsDomain.Add(ToDomain(product));
            }
            return productsDomain;
        }

        public static ProductResponse ToResponse(this Product product)
        {
            return new ProductResponse
            {
                Name = product.Name,
                Description = product.Description,
            };
        }

        public static IEnumerable<ProductResponse> ToResponse(this IEnumerable<Product> products)
        {
            List<ProductResponse> productsDomain = [];

            foreach (var product in products)
            {
                productsDomain.Add(ToResponse(product));
            }
            return productsDomain;
        }
    }
}
