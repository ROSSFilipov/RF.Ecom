namespace RF.Ecom.Orders.Service.Types;

internal sealed class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field(x => x.GetOrderStatuses())
            .Name("orderStatuses")
            .Type<ListType<NonNullType<OrderStatusModelType>>>()
            .Description("Retrieves a list of all possible order statuses.");

        descriptor
            .Field(x => x.GetOrderAsync(default, default, default, default))
            .Name("order")
            .Type<OrderModelType>()
            .Description("Retrieves an order by its unique identifier.")
            .UseProjection()
            .UseFirstOrDefault();

        descriptor
            .Field(x => x.GetOrdersAsync(default, default, default, default))
            .Name("orders")
            .Type<ListType<OrderModelType>>()
            .Description("Retrieves a list of orders.")
            .UsePaging()
            .UseProjection()
            .UseFiltering();
    }
}
