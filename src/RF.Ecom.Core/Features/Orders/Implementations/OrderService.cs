namespace RF.Ecom.Core.Features.Orders.Implementations;

using GreenDonut.Data;
using Microsoft.EntityFrameworkCore;
using RF.Ecom.Core.Features.Orders.Infrastructure;
using RF.Ecom.Core.Features.Orders.Interfaces;
using RF.Ecom.Core.Features.Orders.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

internal sealed class OrderService : IOrderService
{
    private readonly OrdersContext context;

    public OrderService(OrdersContext context)
    {
        this.context = context;
    }

    public async Task<OrderModel> GetOrderAsync(Guid id, QueryContext<OrderModel> queryContext, CancellationToken cancellationToken)
    {
        return await context.Orders
            .Where(x => x.DomainId == id)
            .MapToOrderModel()
            //.With(queryContext)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Page<OrderModel>> GetOrdersAsync(PagingArguments pagingArguments, QueryContext<OrderModel> queryContext, CancellationToken cancellationToken)
    {
        return await context.Orders
            .MapToOrderModel()
            .With(queryContext)
            .OrderBy(x => x.Id)
            .ToPageAsync(pagingArguments, cancellationToken);
    }
}