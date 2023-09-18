using Microsoft.AspNetCore.Identity;

namespace OrdersApp.Core.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        #region Properties

        public string? PersonName { get; set; }
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpirationDateTime { get; set; }

        #endregion
    }
}
