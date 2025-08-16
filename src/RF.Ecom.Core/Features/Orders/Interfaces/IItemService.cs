namespace RF.Ecom.Core.Features.Orders.Interfaces;

using GreenDonut.Data;
using RF.Ecom.Core.Features.Orders.Models;

public interface IItemService
{
    Task<Page<ItemModel>> GetItemsByOrderIdAsync(int id, PagingArguments pagingArguments, QueryContext<ItemModel> queryContext, CancellationToken cancellationToken);
}
