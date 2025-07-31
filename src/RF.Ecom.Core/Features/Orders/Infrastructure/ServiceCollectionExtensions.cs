namespace RF.Ecom.Core.Features.Orders.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds <see cref="OrdersDbContext"/> to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The source of application settings.</param>
    /// <returns><see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddOrderFeatures(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrdersDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Orders");
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}