namespace RF.Ecom.Core.Features.Orders.Entities;

public sealed class ItemEntity
{
    public int Id { get; set; }

    public Guid DomainId { get; set; }

    public int OrderId { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public OrderEntity Order { get; set; }
}
