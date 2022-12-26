using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CodingJobs.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediator(options => { options.ServiceLifetime = ServiceLifetime.Scoped; });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}