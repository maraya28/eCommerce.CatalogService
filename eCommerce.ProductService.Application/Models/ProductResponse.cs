using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.ProductService.Application.Models
{
    public class ProductResponse
    {
        public required string Name { get; set; }

        public required string Description { get; set; }
    }
}
