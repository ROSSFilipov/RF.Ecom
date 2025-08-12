namespace RF.Ecom.Core.Features.Orders.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RF.Ecom.Core.Features.Orders.Implementations;
using RF.Ecom.Core.Features.Orders.Interfaces;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds <see cref="OrdersContext"/> to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The source of application settings.</param>
    /// <returns><see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddOrderFeatures(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrdersContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Orders");
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IItemService, ItemService>();
        services.AddItemsDataLoader();
        return services;
    }
}