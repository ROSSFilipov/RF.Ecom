namespace RF.Ecom.Orders.Service.Types;

using HotChocolate.Data.Filters;
using RF.Ecom.Core.Features.Orders.Entities;

internal sealed class OrderFilterType : FilterInputType<OrderEntity>
{
    protected override void Configure(IFilterInputTypeDescriptor<OrderEntity> descriptor)
    {
        descriptor.Name("orderFilter");

        descriptor
            .Field(x => x.Status)
            .Name("status")
            .Type<OrderStatusFilterInputType>()
            .Description("The current status of the order.");
    }
}