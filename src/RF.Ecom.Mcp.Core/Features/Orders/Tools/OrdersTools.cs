namespace RF.Ecom.Mcp.Core.Features.Orders.Tools;

using ModelContextProtocol.Server;
using RF.Ecom.Mcp.Core.Features.Orders;
using System.ComponentModel;
using System.Text.Json;

[McpServerToolType]
public static class OrdersTools
{
    private const int MaxOrdersCount = 5;

    [McpServerTool(Name = "get_order", Title = "Returns information about an order based on a provided id.")]
    [Description(@"
    Allows the user to retrieve information about an order by providing an id. The user should be aware of the following considerations:
    - The order id must be a valid uuid.
    - The status of the order is represented by its numeric value. The list of all available statuses can be retrieved if the user wants to get more information.")]
    public static async Task<string> GetOrderAsync(
        IOrdersClient client,
        [Description("The order id.")] Guid id,
        CancellationToken cancellationToken)
    {
		try
		{
			var result = await client.GetOrder.ExecuteAsync(id, cancellationToken);
            if (result.Errors.Any())
			{
				return string.Join(", ", result.Errors.Select(e => e.Message));
            }

			if (result.Data.Order != null)
			{
                return JsonSerializer.Serialize(result.Data.Order);
            }

			return "Order not found.";
        }
		catch (Exception ex)
		{
			return ex.ToString();
		}
    }

    [McpServerTool(Name = "get_orders", Title = "Returns information about mutiple orders.")]
    [Description(@"
    Allows the user to retrieve a list of orders. The tool can be used when the user wants to get information about multiple orders.
    The user is currently allowed to filter orders only by status. The response consist of:
    - Total count property which shows the total number of orders based on the user filter criteria.
    - Cursor paging info with fields hasNextPage and hasPrevious page which indicates if there are more records before or after the current set of orders.
    The paging info response also contains properties after and before which can be used in the parameters if the user requests next or previous set/page or orders.")]
    public static async Task<string> GetOrdersAsync(
        IOrdersClient client,
        [Description(@"The parameter is optional and allows the user to select how many orders should be requested starting from the first in the list. The user should be aware of the following considerations:
        - Only positive numbers are allowed
        - The number cannot exceed the allowed maximum of 5 orders at a time.")] int? first = null,
        [Description(@"The parameter is optional and allows the user to select how many orders should be requested starting from the last in the list. The user should be aware of the following considerations:
        - Only positive numbers are allowed
        - The number cannot exceed the allowed maximum of 5 orders at a time.")] int? last = null,
        [Description("The parameter is optional and can be used to retrieve the next page of orders in case the response paging info hasNextPage property has a value of true.")] string after = null,
        [Description("The parameter is optional can be used to retrieve the previous page of orders in case the response paging info hasPreviousPage property has a value of true.")] string before = null,
        [Description("The parameter is optional can be used to filter orders by status.")] int? status = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            orderFilter filter = null;
            if (status.HasValue)
            {
                filter = new orderFilter
                {
                    Status = new OrderStatusFilterInput()
                    {
                        Eq = status
                    }
                };
            }

            var firstParameter = MaxOrdersCount;
            if (first.HasValue)
            {
                firstParameter = Math.Min(first.Value, MaxOrdersCount);
            }

            var lastParameter = MaxOrdersCount;
            if (last.HasValue)
            {
                lastParameter = Math.Min(last.Value, MaxOrdersCount);
            }

            var result = await client.GetOrders.ExecuteAsync(firstParameter, lastParameter, after, before, filter, cancellationToken);
            if (result.Errors.Any())
            {
                return string.Join(", ", result.Errors.Select(e => e.Message));
            }

            if (result.Data.Orders != null)
            {
                return JsonSerializer.Serialize(result.Data.Orders);
            }

            return "Orders not found.";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }
}
