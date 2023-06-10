using Application.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceCollectionExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(CreateEmployeeCommandHandler).Assembly);
        });
        
        return services;
    }
}