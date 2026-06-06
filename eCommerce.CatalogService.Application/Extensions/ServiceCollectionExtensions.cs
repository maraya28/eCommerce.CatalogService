using eCommerce.CatalogService.Application.Contracts;
using eCommerce.CatalogService.Application.Implementations;
using eCommerce.CatalogService.Application.Listeners;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.CatalogService.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<IDistributedCache, DistributedCache>();
            services.AddHostedService<ProductListener>();
            return services;
        }
    }
}
