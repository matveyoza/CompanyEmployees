using CompanyEmployees.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

//ThisIsMySuperLongAndVerySecretKeyForJWT123456!

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly Service.Contracts.IAuthenticationService _authentication;
        public AuthenticationController(Service.Contracts.IAuthenticationService authentication) => _authentication = authentication;

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _authentication.RegisterUser(userForRegistration);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authentication.ValidateUser(user))
                return Unauthorized();

            var token = await _authentication
                .CreateToken(populateExp: true);
            return Ok(token);
        }
    }
}
