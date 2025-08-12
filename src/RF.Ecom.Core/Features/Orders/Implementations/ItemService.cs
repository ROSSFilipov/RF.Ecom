namespace RF.Ecom.Core.Features.Orders.Implementations;

using GreenDonut;
using RF.Ecom.Core.Features.Orders.Interfaces;
using RF.Ecom.Core.Features.Orders.Models;

internal sealed class ItemService : IItemService
{
    private readonly IItemsByOrderIdDataLoader dataLoader;

    public ItemService(IItemsByOrderIdDataLoader dataLoader)
    {
        this.dataLoader = dataLoader;
    }

    public async Task<IEnumerable<ItemModel>> GetItemsByOrderIdAsync(int id, CancellationToken cancellationToken)
    {
        return await dataLoader.LoadRequiredAsync(id, cancellationToken);
    }
}
