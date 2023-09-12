using BL.DTO;
using System.Security.Claims;

namespace BL.Auth;

public interface IJWTManagerRepository
{
    UserDTO UserAuthenticate(string email, string password);
    Tokens GenerateToken(string userName);
    Tokens GenerateRefreshToken(string userName);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

}


