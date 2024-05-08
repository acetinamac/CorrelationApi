using CorrelationApi.Configuration;
using CorrelationApi.Configuration.Interfaces;

namespace CorrelationApi.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdManager(this IServiceCollection services)
    {
        services.AddScoped<ICorrelationGenerator, CorrelationGenerator>();
        return services;
    }
}