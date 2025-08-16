namespace RF.Ecom.Core.Features.Orders.Implementations;

using GreenDonut;
using GreenDonut.Data;
using Microsoft.EntityFrameworkCore;
using RF.Ecom.Core.Features.Orders.Infrastructure;
using RF.Ecom.Core.Features.Orders.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

internal static class ItemsDataLoader
{
    [DataLoader]
    public static async Task<Dictionary<int, Page<ItemModel>>> GetItemsByOrderIdAsync(
        IReadOnlyList<int> orderIds,
        PagingArguments pagingArguments,
        QueryContext<ItemModel> queryContext,
        OrdersContext context,
        CancellationToken cancellationToken)
    {
        return await context.Items
            .Where(item => orderIds.Contains(item.OrderId))
            .MapToItemModel()
            .With(queryContext)
            .OrderBy(item => item.Id)
            .ToBatchPageAsync(x => x.OrderId, pagingArguments, cancellationToken);
    }
}