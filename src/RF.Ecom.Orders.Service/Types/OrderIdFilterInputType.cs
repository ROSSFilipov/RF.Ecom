namespace RF.Ecom.Orders.Service.Types;

using HotChocolate.Data.Filters;

internal sealed class OrderIdFilterInputType : IdOperationFilterInputType
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultFilterOperations.Equals).Type<IdType>();
        descriptor.Operation(DefaultFilterOperations.NotEquals).Type<IdType>();
    }
}
