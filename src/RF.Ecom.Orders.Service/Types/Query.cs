namespace RF.Ecom.Orders.Service.Types;

using GreenDonut.Data;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using RF.Ecom.Core.Features.Orders.Entities;
using RF.Ecom.Core.Features.Orders.Enumerations;
using RF.Ecom.Core.Features.Orders.Infrastructure;
using RF.Ecom.Core.Features.Orders.Interfaces;
using RF.Ecom.Core.Features.Orders.Models;

internal class Query
{
    public IQueryable<OrderEntity> GetOrder(Guid id, [Service] OrdersContext context) => context.Orders.AsNoTracking().OrderBy(x => x.Id).Where(x => x.DomainId == id);

    public IQueryable<OrderEntity> GetOrders([Service] OrdersContext context) => context.Orders.AsNoTracking().OrderBy(x => x.Id);

    public IEnumerable<OrderStatus> GetOrderStatuses() => OrderStatus.List;

    public async Task<OrderModel> GetOrderAsync(
        Guid id,
        QueryContext<OrderModel> queryContext,
        IOrderService orderService,
        CancellationToken cancellationToken)
        => await orderService.GetOrderAsync(id, queryContext, cancellationToken);

    public async Task<Connection<OrderModel>> GetOrdersAsync(
        PagingArguments pagingArguments,
        QueryContext<OrderModel> queryContext,
        IOrderService orderService,
        CancellationToken cancellationToken)
        => await orderService.GetOrdersAsync(pagingArguments, queryContext, cancellationToken).ToConnectionAsync();

    public async Task<IEnumerable<ItemModel>> GetItemsAsync(
        [Parent] OrderModel order,
        IItemService itemService,
        CancellationToken cancellationToken)
        => await itemService.GetItemsByOrderIdAsync(order.Id, cancellationToken);
}
