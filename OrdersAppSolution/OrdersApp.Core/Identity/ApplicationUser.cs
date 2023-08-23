using Microsoft.AspNetCore.Identity;

namespace OrdersApp.Core.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        #region Properties

        public string? PersonName { get; set; }

        #endregion
    }
}
