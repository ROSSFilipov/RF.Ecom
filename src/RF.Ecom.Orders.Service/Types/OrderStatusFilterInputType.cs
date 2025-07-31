namespace RF.Ecom.Orders.Service.Types;

using HotChocolate.Data.Filters;

internal sealed class OrderStatusFilterInputType : IntOperationFilterInputType
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultFilterOperations.Equals).Type<IntType>();
        descriptor.Operation(DefaultFilterOperations.NotEquals).Type<IntType>();
    }
}
