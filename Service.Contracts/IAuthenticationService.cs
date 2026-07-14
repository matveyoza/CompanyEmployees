using Shared.DataTransferObjects;
using Entities.Common;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<Result> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
