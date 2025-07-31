# RF.Gateway



docker build -t rf-gateway-orders-service -f .\\src\\RF.Gateway.Orders.Service\\Dockerfile .



docker run -d -p 8090:8080 -e DOTNET\_ENVIRONMENT="Development" --name rf-gateway-orders-service rf-gateway-orders-service:latest



dotnet graphql update





Get an order with id e2a1c1d1-0001-0000-0000-000000000002

Request:



{

&nbsp; `id`: `e2a1c1d1-0001-0000-0000-000000000002`

}



Response:

{"Id":"e2a1c1d1000100000000000000000002","Reference":"REF-0002","Status":4,"DateCreated":"2025-06-20T08:22:15+00:00","Items":{"TotalCount":2,"Nodes":\[{"Id":"f2a1c1d1000200000000000000000006","Description":"Part F","Price":19.99,"DateCreated":"2025-06-20T08:22:15+00:00"},{"Id":"f2a1c1d1000200000000000000000007","Description":"Unit G","Price":34.56,"DateCreated":"2025-06-20T08:22:15+00:00"}]}}



Here's the information for order ID e2a1c1d1-0001-0000-0000-000000000002:

Order Information:



* Order ID: e2a1c1d1000100000000000000000002
* Reference: REF-0002
* Status: 4
* Date Created: June 20, 2025 at 08:22:15 UTC



Order Items (2 items total):



* Part F - $19.99
* Unit G - $34.56



Total Order Value: $54.55

This order was created on June 20, 2025, and contains fewer items than the previous order. The status value is 4, though without additional context about the system's status codes, I can't specify what this status represents (it could indicate something like "processed," "shipped," "completed," etc.).




[{"Id":"3","Name":"Cancelled","Description":"The order has been cancelled."},{"Id":"2","Name":"Completed","Description":"The order has been completed successfully."},{"Id":"8","Name":"Delivered","Description":"The order has been delivered."},{"Id":"4","Name":"Failed","Description":"The order processing has failed."},{"Id":"6","Name":"OnHold","Description":"The order is on hold."},{"Id":"0","Name":"Pending","Description":"The order is pending and awaiting processing."},{"Id":"1","Name":"Processing","Description":"The order is currently being processed."},{"Id":"5","Name":"Refunded","Description":"The order has been refunded."},{"Id":"9","Name":"Returned","Description":"The order has been returned."},{"Id":"7","Name":"Shipped","Description":"The order has been shipped."}]




