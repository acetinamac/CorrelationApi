using CorrelationApi.Helpers;

namespace CorrelationApi.Services;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder AddCorrelationMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<CorrelationMiddleware>();
}