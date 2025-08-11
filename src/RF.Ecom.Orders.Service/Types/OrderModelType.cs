namespace RF.Ecom.Orders.Service.Types;

using RF.Ecom.Core.Features.Orders.Models;

public sealed class OrderModelType : ObjectType<OrderModel>
{
    protected override void Configure(IObjectTypeDescriptor<OrderModel> descriptor)
    {
        descriptor.Name("orderModel");

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
            .Type<ListType<ItemModelType>>()
            .Description("The list of items in the order.")
            .ResolveWith<ItemResolver>(x => x.GetItemsAsync(default, default, default));
    }
}
