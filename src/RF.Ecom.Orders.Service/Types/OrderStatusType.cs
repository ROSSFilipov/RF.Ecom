namespace RF.Ecom.Orders.Service.Types;

using RF.Ecom.Core.Features.Orders.Enumerations;

internal sealed class OrderStatusType : EnumType<OrderStatus>
{
    protected override void Configure(IEnumTypeDescriptor<OrderStatus> descriptor)
    {
        descriptor.Name("orderStatusEnum");

        descriptor.Value(OrderStatus.Pending)
            .Name(OrderStatus.Pending.ToString().ToUpper())
            .Description(OrderStatus.Pending.Description);

        descriptor
            .Value(OrderStatus.Processing)
            .Name(OrderStatus.Processing.ToString().ToUpper())
            .Description(OrderStatus.Processing.Description);

        descriptor
            .Value(OrderStatus.Completed)
            .Name(OrderStatus.Completed.ToString().ToUpper())
            .Description(OrderStatus.Completed.Description);

        descriptor
            .Value(OrderStatus.Cancelled)
            .Name(OrderStatus.Cancelled.ToString().ToUpper())
            .Description(OrderStatus.Cancelled.Description);

        descriptor
            .Value(OrderStatus.Failed)
            .Name(OrderStatus.Failed.ToString().ToUpper())
            .Description(OrderStatus.Failed.Description);

        descriptor
            .Value(OrderStatus.Refunded)
            .Name(OrderStatus.Refunded.ToString().ToUpper())
            .Description(OrderStatus.Refunded.Description);

        descriptor
            .Value(OrderStatus.OnHold)
            .Name(OrderStatus.OnHold.ToString().ToUpper())
            .Description(OrderStatus.OnHold.Description);

        descriptor.Value(OrderStatus.Shipped)
            .Name(OrderStatus.Shipped.ToString().ToUpper())
            .Description(OrderStatus.Shipped.Description);

        descriptor
            .Value(OrderStatus.Delivered)
            .Name(OrderStatus.Delivered.ToString().ToUpper())
            .Description(OrderStatus.Delivered.Description);

        descriptor
            .Value(OrderStatus.Returned)
            .Name(OrderStatus.Returned.ToString().ToUpper())
            .Description(OrderStatus.Returned.Description);
    }
}
