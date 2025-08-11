namespace RF.Ecom.Orders.Service.Types;

using RF.Ecom.Core.Features.Orders.Interfaces;
using RF.Ecom.Core.Features.Orders.Models;

public class ItemResolver
{
    public async Task<IEnumerable<ItemModel>> GetItemsAsync(
        [Parent] OrderModel order, 
        IItemService itemService, 
        CancellationToken cancellationToken)
        => await itemService.GetItemsByOrderIdAsync(order.Id, cancellationToken);
}
