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
    public static async Task<Dictionary<int, ItemModel[]>> GetItemsByOrderIdAsync(
        IReadOnlyList<int> orderIds, 
        OrdersContext context,
        CancellationToken cancellationToken)
    {
        return await context.Items
            .Where(item => orderIds.Contains(item.OrderId))
            .MapToItemModel()
            .GroupBy(x => x.OrderId)
            .Select(x => new { x.Key, Items = x.OrderBy(item => item.Id).ToArray() })
            .ToDictionaryAsync(x => x.Key, x => x.Items, cancellationToken);
    }
}