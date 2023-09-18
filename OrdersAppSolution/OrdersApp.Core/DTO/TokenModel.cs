using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Core.DTO
{
    public class TokenModel
    {
        #region Properties

        public string? Token { get; set; }
        public string? RefreshToken { get; set; }

        #endregion
    }
}
