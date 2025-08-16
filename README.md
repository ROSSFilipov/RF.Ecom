# Ecom MCP server
This project demonstrates a [model context protocol](https://modelcontextprotocol.io/overview) server implementation which is integrated a GraphQL server.

While following development and architectural best practices is always recommended this project is not purposed to teach some of the modern and popular concepts such as domain driven design or layered architecture to name a few (though some elements of the mentioned concepts can still be found).

## Structure
The solution consists of the following projects:

 - `RF.Ecom.Core` - a class library that keeps common e-commerce related domain logic.
 - `RF.Ecom.Infrastructure` - a class library keeping infrastructure-related logic.
 - `RF.Ecom.Orders.Database` - an SQL database project used for database development and deployment.
 - `RF.Ecom.Orders.Service` - an GraphQL server implementation.
 - `RF.Ecom.Mcp.Core` - a project to keep core model context protocol logic such as tools, prompts and resources.
 - `RF.Ecom.Mcp.Stdio` - A model context protocol server using standard IO transfer protocol.
 - `RF.Ecom.Mcp.Http` A model context protocol server using http transfer protocol.

## Resources
Here is a list of resources and projects based on which the solution is build:

 - The official [MCP SDK 0.3.0-preview.3](https://github.com/modelcontextprotocol/csharp-sdk) for dotnet which at the time of writing this project guide is in a beta version.
 - [Docker Desktop](https://www.docker.com/) and `docker-compose`.
 - The most popular GraphQL SDK for dotnet [Hot Chocolate](https://chillicream.com/) `v15.1.8`.
 - An enumeration class implementation by [Ardalis Smart Enums](https://github.com/ardalis/SmartEnum).
 - [Aspire Dashboard](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/dashboard/standalone?tabs=bash) - the standalone version.
 - [Open Telemetry SDK](https://opentelemetry.io/docs/languages/dotnet/) for dotnet `v1.12.0`.
 - [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) for database access.
 - MS SQL Server 2022 as a `Docker` image.
 - [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
 - MCP client such as [VS Code](https://code.visualstudio.com/) or [Claude Desktop](https://claude.ai/download).

## Getting Started

The following prerequisites are required to build and run the solution:

 - [Docker Desktop](https://www.docker.com/)
 - MCP server compatible host/client

The recommended way to run the solution is by using `docker-compose` with the following command in the root folder of the solution (where the `docker-compose.yml` file is located):

    docker-compose up -d
More information about using `docker-compose` can be found in the [official documentation](https://docs.docker.com/reference/cli/docker/compose/). The docker compose file has been tested on version `v2.38.2-desktop.1`.

#### Observability

The setup includes [Aspire Dashboard](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/dashboard/standalone?tabs=bash) standalone version that can be accessed at `http://localhost:18888`. It is an excellent tool to consume and display `open telemetry` data that can be used outside of traditional `Aspire` setups. The `docker-compose.yml` includes the environment variable `ASPIRE_DASHBOARD_UNSECURED_ALLOW_ANONYMOUS=true` which deactivates the dashboard authentication so you don't have to check container logs for an access token. Such approach is acceptable for a local development environment.
>In addition `Aspire` support will be added in a future version of the project.

#### Data access

The data access is done via [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) for convenience and the database used is MS SQL Server however entity framework migrations are nowhere to be found. Instead the database management is done using [SQL database project](https://learn.microsoft.com/en-us/sql/tools/sql-database-projects/get-started?view=sql-server-ver17&pivots=sq1-visual-studio) which is a powerful tool for database modelling and deployment. The database project itself includes not only the database schema but also post-deployment scripts for seeding data. Once the MS SQL Server container is up and running all that is required is right-clicking on the database project and choosing `Publish` - this will result in a dialog box where you need to configure the connection to the container. After the database has been created the process will execute automatically the data seed script and your database will be ready. In case the container is shut down the data will be preserved in a volume which is a part of the `docker-compose.yml`.

>Software engineers are often tempted to include database schema changes or data seeding logic as a part of the application startup - while convenient it is highly recommended to avoid this strategy. More information can be found at https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli#apply-migrations-at-runtime.

#### MCP
The protocol currently defines two standard transport mechanisms for client-server communication -  `stdio` (or standard input/output) and `http` and the solution has one starter project for each one of these - `RF.Ecom.Mcp.Stdio` and `RF.Ecom.Mcp.Http`. Both of these can be used for local development environment and **both** of these projects can be ran in a container however I prefer the `http` version since it fits the docker compose setup better and provides a way to communicate with the server in a familiar way.

In order to interact with the functionalities an model context protocol server has to offer  you need a client which has MCP integration support. `Visual Studio Code` and `Claude Desktop` for example are such tools that can be configured to connect to an MCP server (local or remote). At the time of writing this article I do recomment using `Visual Studio Code` for the sole reason that it has direct support for both `stdio`and `http` transport protocols while `Claude Desktop` has `http` integration support only for subscriptions meaning if you have a free version you can only use the console MCP server to connect.

To register the MCP server with `VS Code` you need to create/modify the `mcp.json` file which on Windows can usually be found at `C:\Users\<username>\AppData\Roaming\Code\User\mcp.json` and include the following content:

```json
{
   "servers":{
      "ecom-mcp-http":{
         "url":"http://localhost:8092",
         "type":"http"
      }
   }
}
```
`localhost:8092` is the address of the MCP server hosted in the docker compose network. 

In `VS Code` you can open the Copilot chat and switch to `agent` mode then a small tool-icon will appear in the bottom right corner. Clicking on this icon will open a search box where you can type `ecom` and the mcp servers should be available. 
Here are some of the prompts that you can use to test the MCP server:

**Prompt**:
> I need information about order with id e2a1c1d1-0001-0000-0000-000000000016.

**Response**:

> Here is the information about the order with ID e2a1c1d1-0001-0000-0000-000000000016:
>-   Reference: REF-0016
->   Status: 5
->   Date Created: 2025-07-04 16:15:20 UTC
>-   Items:
>    -   ID: f2a1c1d1-0016-0000-0000-000000000035
>    -   Description: Gadget AI
>    -   Price: 77.66
>    -   Date Created: 2025-07-04 16:15:20 UTC
If you need more details about the status or items, let me know!

**Prompt**:

> I need more information about order statuses.

**Response**:

> Here are the available order statuses:
> -   0: Pending – The order is pending and awaiting processing.
> -   1: Processing – The order is currently being processed.
> -   2: Completed – The order has been completed successfully.
> -   3: Cancelled – The order has been cancelled.
> -   4: Failed – The order processing has failed.
> -   5: Refunded – The order has been refunded.
> -   6: OnHold – The order is on hold.
> -   7: Shipped – The order has been shipped.
> -   8: Delivered – The order has been delivered.
> -   9: Returned – The order has been returned.
> 
> Let me know if you need details about a specific status.

**Prompt**:

> How many failed orders do we have in total ?

**Response**:

> There are a total of 12 failed orders in the system. If you need details about these orders or want to see more, just let me know!
