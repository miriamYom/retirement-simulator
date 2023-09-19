
using BL.BLImplements;
using BL.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BL.Auth
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        
        private readonly IConfiguration iconfiguration;
        public IUserServiceBL userServiceBL;

        public JWTManagerRepository(IConfiguration iconfiguration, IUserServiceBL userServiceBL)
        {
            this.iconfiguration = iconfiguration;
            this.userServiceBL = userServiceBL; 
        }

        public UserDTO UserAuthenticate(string email, string password)
        {
            UserDTO user = userServiceBL.Login(email, password);
            return user;
        }

        //public Tokens GenerateToken(string userName)
        //{
        //    return GenerateJWTTokens(userName);
        //}

        //public Tokens GenerateRefreshToken(string username)
        //{
        //    return GenerateJWTTokens(username);
        //}

        public Tokens GenerateAdminRefreshToken(UserDTO adminsData)
        {
            return GenerateJWTAdminTokens(adminsData);
        }

        public Tokens GenerateUserRefreshToken(string email)
        {
            return GenerateJWTUserTokens(email);
        }

        //public Tokens GenerateJWTTokens(string email)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //          {
        //         new Claim(ClaimTypes.Name, email)
        //          }),
        //            Expires = DateTime.Now.AddMinutes(1),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        //        };
        //        var token = tokenHandler.CreateToken(tokenDescriptor);
        //        var refreshToken = GenerateRefreshToken();
        //        return new Tokens { Token = tokenHandler.WriteToken(token), RefreshToken = refreshToken };
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public Tokens GenerateUserToken(string email)
        {
            return GenerateJWTUserTokens(email);
        }

        public Tokens GenerateJWTUserTokens(string email)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
                    //new Claim("mongoId", user.Id),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, "User"),
                  }),
                    Expires = DateTime.Now.AddMinutes(100),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var refreshToken = GenerateRefreshToken();
                return new Tokens { Token = tokenHandler.WriteToken(token), RefreshToken = refreshToken };
            }
            catch (Exception)
            {
                return null;
            }
        }


        public Tokens GenerateAdminToken(UserDTO adminsData)
        {
            return GenerateJWTAdminTokens(adminsData);
        }

        public Tokens GenerateJWTAdminTokens(UserDTO admin)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
                    new Claim("mongoId", admin.Id),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Role, "Admin"),
                  }),
                    Expires = DateTime.Now.AddMinutes(100),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var refreshToken = GenerateRefreshToken();
                return new Tokens { Token = tokenHandler.WriteToken(token), RefreshToken = refreshToken };
            }
            catch (Exception)
            {
                return null;
            }
        }


        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var Key = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }


            return principal;
        }

    }

}
