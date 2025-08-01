namespace RF.Ecom.Infrastructure;

using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds services required for creation of <see cref="ProblemDetails"/> for failed requests.
    /// </summary>
    /// <remarks>Enriches the <see cref="ProblemDetails"/> with additional information such as request method, path, requestId and activity traceId.</remarks>
    /// <param name="services"></param>
    /// <returns>The <see cref="IServiceCollection\"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services)
    {
        return services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);

                var activity = context.HttpContext.Features.Get<IHttpActivityFeature>();
                context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Activity?.TraceId);
            };
        });
    }
}
