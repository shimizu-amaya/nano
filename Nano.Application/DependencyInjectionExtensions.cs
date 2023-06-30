using Microsoft.Extensions.DependencyInjection;
using Nano.Application.Database;
using Nano.Application.Repositories;

namespace Nano.Application;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMessageRepository, MessageRepository>();

        return services;
    }
    
    public static IServiceCollection AddDatabase(this IServiceCollection services,
        string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => new SqliteConnectionFactory(connectionString));
        services.AddSingleton<DbInitializer>();
        
        return services;
    }
}