using CodingJobs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodingJobs.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            var connectionString = config["Db:ConnectionString"];
            opt.UseMySql(connectionString, new MySqlServerVersion(ServerVersion.AutoDetect(connectionString)));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}