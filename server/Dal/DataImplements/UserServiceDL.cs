namespace DL.DataImplements;

public class UserServiceDL : IUserService
{
    IMongoCollection<User> _usersCollection;

    public UserServiceDL(IDbContext dbContext)
    {
        this._usersCollection = dbContext.Users();
    }

    public async Task<bool> CreateAsync(User user)
    {
        if (user == null)
        {
            // throw new Exception()
            return false;
        }
        try
        {
            await _usersCollection.InsertOneAsync(user);
            return true;
        }
        catch (MongoException e)
        {
            Debug.WriteLine(e);
            return false;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(FilterDefinition<User> filter)
    {
        await _usersCollection.DeleteOneAsync(filter);
        return true;
    }

    public async Task<bool> UpdateAsync(FilterDefinition<User> filter, UpdateDefinition<User> update)
    {
        return await _usersCollection.UpdateOneAsync(filter, update) != null;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var documents = await _usersCollection.Find(_ => true).ToListAsync();
        List<User> users = new List<User>();
        documents.ForEach(user => users.Add(BsonSerializer.Deserialize<User>(user.ToBson())));
        return users;
    }



    public async Task<User> GetAsync(FilterDefinition<User> filter)
    {
        try
        {
            return await _usersCollection.Find(filter).FirstAsync();
        }
        catch (Exception e) { }
        return null;
    }

}
