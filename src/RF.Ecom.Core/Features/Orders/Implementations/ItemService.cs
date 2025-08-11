namespace RF.Ecom.Core.Features.Orders.Implementations;

using Microsoft.EntityFrameworkCore;
using RF.Ecom.Core.Features.Orders.Infrastructure;
using RF.Ecom.Core.Features.Orders.Interfaces;
using RF.Ecom.Core.Features.Orders.Models;

internal sealed class ItemService : IItemService
{
    private readonly OrdersContext context;

    public ItemService(OrdersContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<ItemModel>> GetItemsByOrderIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Items
            .Where(x => x.OrderId == id)
            .Select(x => new ItemModel
            {
                Id = x.Id,
                DomainId = x.DomainId,
                OrderId = x.OrderId,
                Price = x.Price,
                DateCreated = x.DateCreated,
                Description = x.Description
            })
            .OrderBy(x => x.Id)
            .ToListAsync(cancellationToken);
    }
}
