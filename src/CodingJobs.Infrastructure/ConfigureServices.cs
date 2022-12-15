using CodingJobs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodingJobs.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // todo: Add connection string from env
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql("conn", new MySqlServerVersion(ServerVersion.AutoDetect("conn"))));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}