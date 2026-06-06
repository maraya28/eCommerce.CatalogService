using eCommerce.CatalogService.Application.Contracts;
using eCommerce.CatalogService.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.CatalogService.Api.Controllers
{
    /// <summary>
    /// Retrieves Products from Catalog
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductApplication _application, ILogger<ProductsController> logger) : Controller
    {
        /// <summary>
        /// Retrieves a list of Products
        /// </summary>
        /// <param name="pageNumber">pageNumber</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>An enumerable of <see cref="ProductResponse"/>.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<ProductResponse> response = await _application.GetPagedAsync(pageNumber, pageSize);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a Product by id
        /// </summary>
        /// <param name="id">id</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            ProductResponse result = await _application.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
