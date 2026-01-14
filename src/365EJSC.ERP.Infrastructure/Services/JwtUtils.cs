using _365EJSC.ERP.Infrastructure.Abstractions;
using _365EJSC.ERP.Infrastructure.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _365EJSC.ERP.Infrastructure.Services
{
    public class JwtUtils : IJwtUtils
    {
        private string SecretKey = "0!Abcd!@#$%^*eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.IyOTc4OCwiaWF0IjoxNjc5MjI3OTg4fQ.om-viGOfljoR6QaCISQvVDeUZLWfHyByE0jplSxqKDM";//ConfigurationManager.AppSettings["JwtKey"];

        public JwtUtils()
        {
        }

        public string GenerateJwtToken(UsersDTOs user)
        {
            // generate token that is valid for 15 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.id.ToString()), new Claim("type", user.type) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public UsersDTOs ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var user = new UsersDTOs()
                {
                    id = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value),
                    type = jwtToken.Claims.First(x => x.Type == "type").Value
                };

                // return user id from JWT token if validation successful
                return user;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

        //public RefreshToken GenerateRefreshToken(string ipAddress)
        //{
        //    // generate token that is valid for 7 days
        //    using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        //    var randomBytes = new byte[64];
        //    rngCryptoServiceProvider.GetBytes(randomBytes);
        //    var refreshToken = new RefreshToken
        //    {
        //        Token = Convert.ToBase64String(randomBytes),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        Created = DateTime.UtcNow,
        //        CreatedByIp = ipAddress
        //    };

        //    return refreshToken;
        //}
    }
}