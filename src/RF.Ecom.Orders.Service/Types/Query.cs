namespace RF.Ecom.Orders.Service.Types
{
    using Microsoft.EntityFrameworkCore;
    using RF.Ecom.Core.Features.Orders.Entities;
    using RF.Ecom.Core.Features.Orders.Enumerations;
    using RF.Ecom.Core.Features.Orders.Infrastructure;

    internal class Query
    {
        public IQueryable<OrderEntity> GetOrder(Guid id, [Service] OrdersDbContext context) => context.Orders.AsNoTracking().OrderBy(x => x.Id).Where(x => x.DomainId == id);

        public IQueryable<OrderEntity> GetOrders([Service] OrdersDbContext context) => context.Orders.AsNoTracking().OrderBy(x => x.Id);

        public IEnumerable<OrderStatus> GetOrderStatuses() => OrderStatus.List;
    }
}
