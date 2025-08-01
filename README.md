# Ecom MCP server
This project demonstrates a [model context protocol](https://modelcontextprotocol.io/overview) server implementation which is integrated with various sources to retrieve data such as a GraphQL server and a REST API (more can be added in future).

While following development and architectural best practices is always recommended this project is not purposed to teach some of the modern and popular concepts such as domain driven design or clean architecture to name a few (though some elements of the mentioned concepts can still be found).
## Structure
The solution consists of the following projects:

 - `RF.Ecom.Core` - a class library that keeps common e-commerce related domain logic.
 - `RF.Ecom.Infrastructure` - a class library keeping infrastructure-related logic.
 - `RF.Ecom.Orders.Database` - a MS SQL Server database project used for database development and deployment.
 - `RF.Ecom.Orders.Service` - an GraphQL server implementation.
 - `RF.Ecom.Mcp.Core` - a project to keep core model context protocol logic such as tools, prompts and resources.
 - `RF.Ecom.Mcp.Stdio` - A model context protocol server using standard IO transfer protocol.
 - `RF.Ecom.Mcp.Http` A model context protocol server using http transfer protocol.

The naming convention used in project names is an opinionated element however I always recommend to fellow software engineers to follow conventions. And if you do not have conventions - build them and follow them. Conventions are one of the pillars of enterprise architecture.

## Resources
Here is a list of resources and projects based on which the solution is build:

 - The official [MCP SDK 0.3.0-preview.3](https://github.com/modelcontextprotocol/csharp-sdk) for dotnet which at the time of writing this project guide is in a beta version.
 - [Docker Desktop](https://www.docker.com/) and `docker-compose`.
 - The most popular GraphQL SDK for dotnet [Hot Chocolate](https://chillicream.com/).
 - An enumeration class implementation by [Ardalis Smart Enums](https://github.com/ardalis/SmartEnum).
 - [Aspire Dashboard](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/dashboard/standalone?tabs=bash) - the standalone version.
 - [Open Telemetry SDK](https://opentelemetry.io/docs/languages/dotnet/) for dotnet.
 - [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) for MS SQL Server database access.
 - MS SQL Server as a `Docker` image.
 - [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

## Getting Started

The following prerequisites are required to build and run the solution:

 - [Docker Desktop](https://www.docker.com/)
 - MCP server compatible host/client

The recommended way to run the solution is by using `docker-compose` with the following command in the root folder of the solution (where the `docker-compose.yml` file is located):

    docker-compose up -d
More information about using `docker-compose` can be found in the [official documentation](https://docs.docker.com/reference/cli/docker/compose/).
