using Application.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceCollectionExtensions;

/// <summary>
/// Регистрация зависимостей.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрация сервисов, используемых Application.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(CreateEmployeeCommandHandler).Assembly);
        });
        
        return services;
    }
}