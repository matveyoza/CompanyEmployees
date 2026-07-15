using CompanyEmployees.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductsController(IProductService product) => _product = product;

        [HttpGet]
        public async Task<IActionResult> GetProductsForCompany(Guid companyId)
        {
            var products = await _product.GetProductsAsync(companyId, trackChanges: false);
            return Ok(products);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProductForCompany(Guid companyId, [FromBody] ProductForCreationDto product)
        {
            var productToReturn = await _product.CreateProductForCompanyAsync(companyId, product, trackChanges: false);

            return CreatedAtAction(nameof(GetProductsForCompany), new { companyId }, productToReturn);
        }
    }
}
