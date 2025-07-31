namespace RF.Ecom.Orders.Service.Types;

using RF.Ecom.Core.Features.Orders.Entities;

internal sealed class OrderType : ObjectType<OrderEntity>
{
    protected override void Configure(IObjectTypeDescriptor<OrderEntity> descriptor)
    {
        descriptor.Name("order");

        descriptor
            .Field(x => x.DomainId)
            .Name("id")
            .Type<NonNullType<IdType>>()
            .Description("The unique identifier of the order.");

        descriptor
            .Field(x => x.Reference)
            .Name("reference")
            .Type<NonNullType<StringType>>()
            .Description("The reference of the order.");

        descriptor
            .Field(x => x.Status)
            .Name("status")
            .Type<NonNullType<IntType>>()
            .Description("The current status of the order.");

        descriptor
            .Field(x => x.DateCreated)
            .Name("dateCreated")
            .Type<NonNullType<DateTimeType>>()
            .Description("The date and time when the order was created.");

        descriptor
            .Field(x => x.Items)
            .Name("items")
            .Type<ListType<ItemType>>()
            .Description("The list of items in the order.");
    }
}
