using OrdersApp.Core.DTO;
using OrdersApp.Core.Identity;

namespace OrdersApp.Core.ServicesContracts
{
    public interface IJwtService
    {
        #region Methods

        AuthenticationResponse CreateJwtToken(ApplicationUser user);

        #endregion
    }
}
