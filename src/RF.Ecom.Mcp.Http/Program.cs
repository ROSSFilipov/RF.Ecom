using RF.Ecom.Mcp.Core.Features.Orders.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddOrdersInfrastructure(builder.Configuration);
builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithToolsFromAssembly(typeof(RF.Ecom.Mcp.Core.AssemblyMark).Assembly)
    .WithPromptsFromAssembly(typeof(RF.Ecom.Mcp.Core.AssemblyMark).Assembly);

var app = builder.Build();

app.MapMcp();

app.Run();