namespace RF.Ecom.Mcp.Core.Features.Orders.Tools;

using ModelContextProtocol.Server;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

[McpServerToolType]
public static class OrderStatusesTool
{
    [McpServerTool(Name = "get_order_statuses", Title = "Returns a list of available order statuses.")]
    [Description(@"
    Allows the user to get a list of all available order statuses. This tool can be used in the following scenarios:
    - To retrieve the list of all available order statuses
    - In case the user wants to get more information about. specific status and the list of statuses is not available.
    - In case the user encounters an unkown status.")]
    public static async Task<string> GetOrderStatusesAsync(
    IOrdersClient client,
    CancellationToken cancellationToken)
    {
        try
        {
            var result = await client.GetOrderStatuses.ExecuteAsync(cancellationToken);
            if (result.Errors.Any())
            {
                return string.Join(", ", result.Errors.Select(e => e.Message));
            }

            if (result.Data.OrderStatuses != null)
            {
                return JsonSerializer.Serialize(result.Data.OrderStatuses);
            }

            return "Order not found.";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }
}
