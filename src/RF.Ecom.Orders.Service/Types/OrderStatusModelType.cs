namespace RF.Ecom.Orders.Service.Types;

using RF.Ecom.Core.Features.Orders.Enumerations;

internal sealed class OrderStatusModelType : ObjectType<OrderStatus>
{
    protected override void Configure(IObjectTypeDescriptor<OrderStatus> descriptor)
    {
        descriptor.Name("orderStatus");

        descriptor
            .Field(x => x.Value)
            .Name("id")
            .Type<NonNullType<IdType>>()
            .Description("The unique identifier of the order status.");

        descriptor
            .Field(x => x.Name)
            .Name("name")
            .Type<NonNullType<StringType>>()
            .Description("The name of the order status.");

        descriptor
            .Field(x => x.Description)
            .Type<NonNullType<StringType>>()
            .Description("A description of the order status.");
    }
}
