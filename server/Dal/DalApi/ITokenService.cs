using DL.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DalApi
{
    public interface ITokenService
    {
        Task AddUserRefreshTokens(UserRefreshToken usersToken);
        Task<UserRefreshToken> GetSavedRefreshTokens(string email, string refreshtoken);
        Task DeleteUserRefreshTokens(string email, string refreshToken);

    }
}
