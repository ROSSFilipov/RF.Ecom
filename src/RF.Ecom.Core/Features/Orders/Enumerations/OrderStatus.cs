namespace RF.Ecom.Core.Features.Orders.Enumerations;

using Ardalis.SmartEnum;

public sealed class OrderStatus : SmartEnum<OrderStatus, int>
{
    public static readonly OrderStatus Pending = new("Pending", 0, "The order is pending and awaiting processing.");
    public static readonly OrderStatus Processing = new("Processing", 1, "The order is currently being processed.");
    public static readonly OrderStatus Completed = new("Completed", 2, "The order has been completed successfully.");
    public static readonly OrderStatus Cancelled = new("Cancelled", 3, "The order has been cancelled.");
    public static readonly OrderStatus Failed = new("Failed", 4, "The order processing has failed.");
    public static readonly OrderStatus Refunded = new("Refunded", 5, "The order has been refunded.");
    public static readonly OrderStatus OnHold = new("OnHold", 6, "The order is on hold.");
    public static readonly OrderStatus Shipped = new("Shipped", 7, "The order has been shipped.");
    public static readonly OrderStatus Delivered = new("Delivered", 8, "The order has been delivered.");
    public static readonly OrderStatus Returned = new("Returned", 9, "The order has been returned.");

    private OrderStatus(string name, int value, string description)
        : base(name, value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description, nameof(description));
        Description = description;
    }

    public string Description { get; }
}
