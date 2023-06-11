using Domain.AggregationModels.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.UnitOfWork;

namespace Persistence;

/// <summary>
/// Регистрация зависимостей для Peristence слоя.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EmployeeContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("EmployeeConnectionString"), sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(EmployeeContext).Assembly.FullName);
            });
        }); // Scoped by default

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}