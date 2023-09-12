using DL.DataObjects;
using Microsoft.AspNetCore.Identity;

namespace DL.DataImplements;

public class TokenService: ITokenService
{

    private readonly IMongoCollection<UserRefreshToken> userRefreshTokens;
    public TokenService(IDbContext db)
    {
        userRefreshTokens = db.UserRefreshTokens();
    }
    public Task AddUserRefreshTokens(UserRefreshToken usersToken)
    {
        return userRefreshTokens.InsertOneAsync(usersToken);
    }

    public Task DeleteUserRefreshTokens(string userId, string refreshToken)
    {
        var f1 = Builders<UserRefreshToken>.Filter.Eq(t => t.Id, userId);
        var f2 = Builders<UserRefreshToken>.Filter.Eq(t => t.RefreshToken, refreshToken);
        return userRefreshTokens.DeleteOneAsync(f1 & f2);
    }

    public Task<UserRefreshToken> GetSavedRefreshTokens(string email, string refreshToken)
    {
        return userRefreshTokens.Find(user => user.Email == email && user.RefreshToken == refreshToken).FirstOrDefaultAsync();
    }

}
