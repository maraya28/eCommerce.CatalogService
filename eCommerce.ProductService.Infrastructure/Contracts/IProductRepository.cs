using eCommerce.ProductService.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.ProductService.Infrastructure.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetPagedAsync(int pageNumber, int pageSize);

        Task<ProductEntity?> GetByIdAsync(string id);
    }
}
