namespace RF.Ecom.Core.Features.Orders.Infrastructure
{
    using RF.Ecom.Core.Features.Orders.Entities;
    using RF.Ecom.Core.Features.Orders.Models;
    using System.Linq;

    internal static class MappingExtensions
    {
        public static IQueryable<OrderModel> MapToOrderModel(this IQueryable<OrderEntity> query)
        {
            return query.Select(order => new OrderModel
            {
                Id = order.Id,
                DomainId = order.DomainId,
                DateCreated = order.DateCreated,
                Status = order.Status,
                Reference = order.Reference,
                Items = order.Items.Select(item => new ItemModel
                {
                    Id = item.Id,
                    DomainId = item.DomainId,
                    DateCreated = item.DateCreated,
                    Description = item.Description,
                    Price = item.Price
                })
            });
        }
    }
}
