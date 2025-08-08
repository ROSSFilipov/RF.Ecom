namespace RF.Ecom.Core.Features.Orders.Models;

public sealed class ItemModel
{
    public int Id { get; init; }

    public int OrderId { get; init; }

    public Guid DomainId { get; init; }

    public string Description { get; init; }

    public decimal Price { get; init; }

    public DateTimeOffset DateCreated { get; init; }
}
