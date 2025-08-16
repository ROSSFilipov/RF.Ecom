namespace RF.Ecom.Orders.Service.Types;

using GreenDonut.Data;
using HotChocolate.Types.Pagination;
using RF.Ecom.Core.Features.Orders.Enumerations;
using RF.Ecom.Core.Features.Orders.Interfaces;
using RF.Ecom.Core.Features.Orders.Models;

internal class Query
{
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

    public async Task<Connection<ItemModel>> GetItemsAsync(
        [Parent] OrderModel order,
        PagingArguments pagingArguments,
        QueryContext<ItemModel> queryContext,
        IItemService itemService,
        CancellationToken cancellationToken)
        => await itemService.GetItemsByOrderIdAsync(order.Id, pagingArguments, queryContext, cancellationToken).ToConnectionAsync();
}
