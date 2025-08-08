namespace RF.Ecom.Core.Features.Orders.Interfaces;

using GreenDonut.Data;
using RF.Ecom.Core.Features.Orders.Models;

internal interface IOrderService
{
    Task<OrderModel> GetOrderAsync(Guid id, QueryContext<OrderModel> queryContext, CancellationToken cancellationToken);

    Task<Page<OrderModel>> GetOrdersAsync(PagingArguments pagingArguments, QueryContext<OrderModel> queryContext, CancellationToken cancellationToken);
}
