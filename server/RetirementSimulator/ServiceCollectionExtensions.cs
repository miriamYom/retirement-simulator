using BL.BLImplements;
using BL.Pension;
using BL.Profiles;
using DL;
using Microsoft.Extensions.DependencyInjection;

namespace BL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection collection/*, IConfiguration config*/)
    {
        collection.AddSingleton<IUserServiceBL, UserServiceBL>();
        collection.AddSingleton< IPensionFactory , PensionFactory >();
        collection.AddAutoMapper(typeof(UserProfile),typeof(UserRefreshTokenProfile));
        collection.AddScoped<ITokenServiceBL, TokenServiceBL>();

        collection.AddRepositories(/*config*/);
        return collection;
    }
}
