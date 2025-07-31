using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RF.Ecom.Mcp.Core.Features.Orders.Infrastructure;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("appsettings.*.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddOrdersInfrastructure(builder.Configuration);

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly(typeof(RF.Ecom.Mcp.Core.AssemblyMark).Assembly);

var app = builder.Build();

await app.RunAsync();