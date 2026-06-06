using eCommerce.CatalogService.Infrastructure.Contracts;
using eCommerce.CatalogService.Infrastructure.Implementations;
using eCommerce.CatalogService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.CatalogService.Infrastructure.Extensions
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
