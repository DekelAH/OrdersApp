using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrdersApp.Core.DTO;
using OrdersApp.Core.Identity;
using OrdersApp.Core.ServicesContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
                new Claim(ClaimTypes.Name, user.PersonName),
                new Claim(ClaimTypes.Email, user.Email)
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

            return new AuthenticationResponse
            {
                Token = token,
                Email = user.Email,
                PersonName = user.PersonName,
                Expiration = expiration,
                RefreshToken = GetRefreshToken(),
                RefreshTokenExpirationDateTime = DateTime.Now.AddMinutes(
                                                 Convert.ToDouble(_configuration["RefreshToken:Expiration_Minutes"]))
            };
        }

        public ClaimsPrincipal? GetClaimsPrincipalFromJwtToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:Audience"],
                ValidateIssuer = true,
                ValidIssuer = _configuration["JWT:Issuer"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenSecretKey"])),
                ValidateLifetime = false
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal claimsPrincipal = jwtSecurityTokenHandler.ValidateToken(token,
                                                                tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return claimsPrincipal;
        }

        private static string GetRefreshToken()
        {
            byte[] bytes = new byte[64];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        #endregion
    }
}
