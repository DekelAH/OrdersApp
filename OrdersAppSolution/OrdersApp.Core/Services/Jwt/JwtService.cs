using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrdersApp.Core.DTO;
using OrdersApp.Core.Identity;
using OrdersApp.Core.ServicesContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrdersApp.Core.Services.Jwt
{
    public class JwtService : IJwtService
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Ctors

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Methods

        public AuthenticationResponse CreateJwtToken(ApplicationUser user)
        {
            DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:Expiration_Minutes"]));
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Name, user.PersonName)
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenSecretKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken tokenGenerator = new JwtSecurityToken
                (
                  _configuration["Jwt:Issuer"],
                  _configuration["Jwt:Audience"],
                  claims,
                  expires: expiration,
                  signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            string token = jwtSecurityTokenHandler.WriteToken(tokenGenerator);

            return new AuthenticationResponse { Token = token, 
                                                Email = user.Email, 
                                                PersonName = user.PersonName,
                                                Expiration = expiration };
        }

        #endregion
    }
}
