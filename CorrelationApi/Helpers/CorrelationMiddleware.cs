using CorrelationApi.Configuration.Interfaces;

namespace CorrelationApi.Helpers;

public class CorrelationMiddleware
{
    private readonly RequestDelegate _next;
    private const string _correlationIdHeader = "X-Correlation-Id";

    public CorrelationMiddleware(RequestDelegate next) => _next = next;
   
    public async Task Invoke(HttpContext context, ICorrelationGenerator correlationGenerator)
    {
        var correlationId = GetCorrelationIdTrace(context, correlationGenerator);
        AddCorrelationToResponse(context, correlationId);
        await _next(context);
    }

    private static string GetCorrelationIdTrace(HttpContext context, ICorrelationGenerator correlationGenerator)
    {
        if (context.Request.Headers.TryGetValue(_correlationIdHeader, out var correlationId))
        {
            correlationGenerator.Set(correlationId!);
            return correlationId!;
        }
        else
        {
            var newCorrelationId = correlationGenerator.Get();
            return newCorrelationId;
        }
    }

    private static void AddCorrelationToResponse(HttpContext context, string correlationId)
    {
        context.Response.OnStarting(() => 
        {
            if (!context.Response.Headers.ContainsKey(_correlationIdHeader))
            {
                context.Response.Headers.Append(_correlationIdHeader, new [] {correlationId});
            }
        
            return Task.CompletedTask;
        });
    }
}