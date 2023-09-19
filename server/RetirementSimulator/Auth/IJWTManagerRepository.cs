using BL.DTO;
using System.Security.Claims;

namespace BL.Auth;

public interface IJWTManagerRepository
{
    UserDTO UserAuthenticate(string email, string password);
    //Tokens GenerateToken(string userName);
    //Tokens GenerateRefreshToken(string userName);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    //--------------------------------------------------
    Tokens GenerateUserToken(string email);
    Tokens GenerateJWTUserTokens(string email);
    Tokens GenerateJWTAdminTokens(UserDTO admin);
    Tokens GenerateAdminToken(UserDTO adminsData);
    Tokens GenerateAdminRefreshToken(UserDTO adminsData);
    Tokens GenerateUserRefreshToken(string email);





}


