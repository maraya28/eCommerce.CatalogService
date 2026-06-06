using eCommerce.CatalogService.Application.Contracts;
using eCommerce.CatalogService.Application.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.CatalogService.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductApplication, ProductApplication>();
            return services;
        }
    }
}
