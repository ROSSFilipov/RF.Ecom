namespace RF.Ecom.Core.Features.Orders.Entities;

internal sealed class OrderEntity
{
    public int Id { get; set; }

    public Guid DomainId { get; set; }

    public string Reference { get; set; }

    public int Status { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public ICollection<ItemEntity> Items { get; set; } = [];
}
