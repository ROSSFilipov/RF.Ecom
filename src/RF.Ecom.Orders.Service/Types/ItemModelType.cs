namespace RF.Ecom.Orders.Service.Types;

using RF.Ecom.Core.Features.Orders.Models;

public class ItemModelType : ObjectType<ItemModel>
{
    protected override void Configure(IObjectTypeDescriptor<ItemModel> descriptor)
    {
        descriptor.Name("itemModel");

        descriptor
            .Field(x => x.DomainId)
            .Name("id")
            .Type<NonNullType<IdType>>()
            .Description("The unique identifier of the item.");

        descriptor
            .Field(x => x.Description)
            .Name("description")
            .Type<NonNullType<StringType>>()
            .Description("The description of the item.");

        descriptor
            .Field(x => x.Price)
            .Name("price")
            .Type<NonNullType<DecimalType>>()
            .Description("The price of the item.");

        descriptor
            .Field(x => x.DateCreated)
            .Name("dateCreated")
            .Type<NonNullType<DateTimeType>>()
            .Description("The date and time when the item was created.");
    }
}
