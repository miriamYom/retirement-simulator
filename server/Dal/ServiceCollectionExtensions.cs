//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection collection /*, IConfiguration config*/)
    {
        collection.AddSingleton<IUserService, UserServiceDL>();
        collection.AddSingleton<IDbContext, DbContext>();
        collection.AddScoped<ITokenService, TokenService>();


        /* string? str = config.GetConnectionString("mongoClient");
         collection.AddDbContext<Library>(options => options.UseSqlServer(connString));*/


        return collection;
    }
}
