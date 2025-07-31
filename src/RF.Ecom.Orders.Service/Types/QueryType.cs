namespace RF.Ecom.Orders.Service.Types;

using HotChocolate.Types.Pagination;

internal sealed class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field(x => x.GetOrder(default, default))
            .Name("order")
            .Type<OrderType>()
            .Description("Retrieves an order by its unique identifier.")
            .UseFirstOrDefault()
            .UseProjection();

        descriptor
            .Field(x => x.GetOrders(default))
            .Name("orders")
            .Type<ListType<NonNullType<OrderType>>>()
            .Description("Retrieves a list of orders.")
            .UsePaging(options: new PagingOptions() { DefaultPageSize = 10, MaxPageSize = 25, IncludeTotalCount = true })
            .UseProjection()
            .UseFiltering<OrderFilterType>();

        descriptor
            .Field(x => x.GetOrderStatuses())
            .Name("orderStatuses")
            .Type<ListType<NonNullType<OrderStatusModelType>>>()
            .Description("Retrieves a list of all possible order statuses.");
    }
}
