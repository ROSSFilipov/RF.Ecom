namespace RF.Ecom.Core.Features.Orders.Implementations;

using GreenDonut.Data;
using RF.Ecom.Core.Features.Orders.Interfaces;
using RF.Ecom.Core.Features.Orders.Models;

internal sealed class ItemService : IItemService
{
    private readonly IItemsByOrderIdDataLoader dataLoader;

    public ItemService(IItemsByOrderIdDataLoader dataLoader)
    {
        this.dataLoader = dataLoader;
    }

    public async Task<Page<ItemModel>> GetItemsByOrderIdAsync(int id, PagingArguments pagingArguments, QueryContext<ItemModel> queryContext, CancellationToken cancellationToken)
    {
        return await dataLoader.With(pagingArguments, queryContext).LoadAsync(id, cancellationToken) ?? Page<ItemModel>.Empty;
    }
}
