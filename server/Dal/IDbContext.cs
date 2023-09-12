
namespace DL;

public interface IDbContext
{
    public IMongoCollection<User> Users();
    public IMongoCollection<UserRefreshToken> UserRefreshTokens();

}
