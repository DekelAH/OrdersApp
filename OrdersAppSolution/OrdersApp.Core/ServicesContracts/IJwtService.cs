using OrdersApp.Core.DTO;
using OrdersApp.Core.Identity;
using System.Security.Claims;

namespace OrdersApp.Core.ServicesContracts
{
    public interface IJwtService
    {
        #region Methods

        AuthenticationResponse CreateJwtToken(ApplicationUser user);
        ClaimsPrincipal? GetClaimsPrincipalFromJwtToken(string? token);

        #endregion
    }
}
