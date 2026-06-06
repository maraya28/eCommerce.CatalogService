using eCommerce.ProductService.Infrastructure.Contracts;
using eCommerce.ProductService.Infrastructure.Implementations;
using eCommerce.ProductService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.ProductService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(dbContext => dbContext.UseInMemoryDatabase("Products"));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
