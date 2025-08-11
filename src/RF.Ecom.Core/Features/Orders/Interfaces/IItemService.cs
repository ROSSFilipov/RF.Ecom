using RF.Ecom.Core.Features.Orders.Models;

namespace RF.Ecom.Core.Features.Orders.Interfaces;

public interface IItemService
{
    Task<IEnumerable<ItemModel>> GetItemsByOrderIdAsync(int id, CancellationToken cancellationToken);
}
