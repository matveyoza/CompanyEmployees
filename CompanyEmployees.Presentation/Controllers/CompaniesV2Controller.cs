using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{

    [ApiVersion("2.0")]
    [Route("api/companies")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class CompaniesV2Controller : ControllerBase
    {
        private readonly ICompanyService _comService;
        public CompaniesV2Controller(ICompanyService comService) => _comService = comService;
        
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _comService.GetAllCompaniesAsync(trackChanges: false);

            var companiesV2 = companies.Select(x => $"{x.Name} V2");
            
            return Ok(companiesV2);
        }
    }
}
