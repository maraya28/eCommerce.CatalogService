using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.CatalogService.Application.Models
{
    public class ProductResponse
    {
        public required string Name { get; set; }

        public required string Description { get; set; }
    }
}
