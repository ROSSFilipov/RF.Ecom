namespace RF.Ecom.Orders.Service.Types;

using HotChocolate.Data.Filters;
using RF.Ecom.Core.Features.Orders.Models;

internal sealed class OrderFilterType : FilterInputType<OrderModel>
{
    protected override void Configure(IFilterInputTypeDescriptor<OrderModel> descriptor)
    {
        descriptor.Name("orderFilter");

        descriptor
            .Field(x => x.Status)
            .Name("status")
            .Type<OrderStatusFilterInputType>()
            .Description("The current status of the order.");
    }
}