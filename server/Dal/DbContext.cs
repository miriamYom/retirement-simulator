
using DL.DataObjects;

namespace DL;

public class DbContext : IDbContext
{
    /// <summary>
    /// how to do the try catch ???????
    /// </summary>
    private IMongoDatabase database;
    public DbContext()
    {
       MongoClient dbClient = new MongoClient("mongodb+srv://miriamYom:m214256190@retirementsimulator.235lldc.mongodb.net/?retryWrites=true&w=majority");
       database = dbClient.GetDatabase("Data");
    }

    public IMongoCollection<User> Users()
    {
        try
        {
            return database.GetCollection<User>("Users");   
        }
        catch(Exception e)
        {
            Debug.WriteLine(e);
            return null;
        }
    }
    public IMongoCollection<UserRefreshToken> UserRefreshTokens()
    {
        try
        {
            return database.GetCollection<UserRefreshToken>("UserRefreshTokens");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null;
        }
    }

}
