namespace RF.Ecom.Core.Features.Orders.Implementations;

using GreenDonut;
using GreenDonut.Data;
using Microsoft.EntityFrameworkCore;
using RF.Ecom.Core.Features.Orders.Infrastructure;
using RF.Ecom.Core.Features.Orders.Models;

internal static class ItemsDataLoader
{
    [DataLoader]
    public static async Task<Dictionary<int, ItemModel>> GetItemsByIdAsync(IReadOnlyList<int> itemIds, OrdersContext context, CancellationToken cancellationToken)
    {
        return await context.Items
            .Where(x => itemIds.Contains(x.Id))
            .Select(item => new ItemModel
            {
                Id = item.Id,
                DomainId = item.DomainId,
                DateCreated = item.DateCreated,
                Description = item.Description,
                Price = item.Price
            })
            .ToDictionaryAsync(item => item.Id, cancellationToken);
    }

    [DataLoader]
    public static async Task<Dictionary<int, Page<ItemModel>>> GetItemsByOrderIdAsync(IReadOnlyList<int> orderIds, PagingArguments pagingArguments, OrdersContext context, CancellationToken cancellationToken)
    {
        return await context.Items
            .Where(x => orderIds.Contains(x.Order.Id))
            .Select(item => new ItemModel
            {
                Id = item.Id,
                DomainId = item.DomainId,
                OrderId = item.Order.Id,
                DateCreated = item.DateCreated,
                Description = item.Description,
                Price = item.Price
            })
            .OrderBy(item => item.Id)
            .ToBatchPageAsync(x => x.OrderId, pagingArguments, cancellationToken);
    }
}
