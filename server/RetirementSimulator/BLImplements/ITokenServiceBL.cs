using BL.DTO;
using DL.DataObjects;

namespace BL.BLImplements
{
    public interface ITokenServiceBL
    {
        Task AddUserRefreshTokens(UserRefreshTokenDTO usersToken);
        Task<UserRefreshToken> GetSavedRefreshTokens(string email, string refreshtoken);
        Task DeleteUserRefreshTokens(string email, string refreshToken);

    }
}
