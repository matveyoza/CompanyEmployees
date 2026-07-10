using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProductsController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetProductsForCompany(Guid companyId)
        {
            var products = await _service.ProductService.GetProductsAsync(companyId, trackChanges: false);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductForCompany(Guid companyId, [FromBody] ProductForCreationDto product)
        {
            if (product == null)
                return BadRequest("ProductForCreationDto object is null");

            var productToReturn = await _service.ProductService.CreateProductForCompanyAsync(companyId, product, trackChanges: false);

            return CreatedAtAction(nameof(GetProductsForCompany), new { companyId }, productToReturn);
        }
    }
}
