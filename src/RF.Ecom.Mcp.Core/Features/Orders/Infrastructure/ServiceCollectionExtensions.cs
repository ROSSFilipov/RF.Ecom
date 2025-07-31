namespace RF.Ecom.Mcp.Core.Features.Orders.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds <see cref="IOrdersClient"/> implementation to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The source of application settings.</param>
    /// <returns><see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddOrdersInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection(OrdersServiceOptions.SectionName).Get<OrdersServiceOptions>();
        ArgumentException.ThrowIfNullOrEmpty(options?.Url, $"{nameof(OrdersServiceOptions)}.{nameof(OrdersServiceOptions.Url)}");

        services.AddOrdersClient().ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri(options.Url);
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("orders-client", "1.0"));
        });

        return services;
    }
}
