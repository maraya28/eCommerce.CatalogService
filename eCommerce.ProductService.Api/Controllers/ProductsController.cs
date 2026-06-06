using eCommerce.ProductService.Application.Contracts;
using eCommerce.ProductService.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.ProductService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(IProductApplication _application) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<ProductResponse> response = await _application.GetPagedAsync(pageNumber, pageSize);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            ProductResponse result = await _application.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
