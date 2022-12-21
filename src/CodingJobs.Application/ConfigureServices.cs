using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CodingJobs.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediator();
        return services;
    }
}