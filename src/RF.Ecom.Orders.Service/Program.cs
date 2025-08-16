using HotChocolate.Diagnostics;
using RF.Ecom.Core.Features.Orders.Infrastructure;
using RF.Ecom.Infrastructure;
using RF.Ecom.Orders.Service.Types;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddCustomProblemDetails();
builder.Services.AddExceptionHandler<ProblemDetailsExceptionHandler>();
builder.Services.AddOrderFeatures(builder.Configuration);
builder.AddGraphQL()
    .ModifyOptions(options => options.DefaultBindingBehavior = BindingBehavior.Explicit)
    .ModifyRequestOptions(options => options.IncludeExceptionDetails = builder.Environment.IsDevelopment())
    .AddType<QueryType>()
    .AddProjections()
    .AddPagingArguments()
    .AddQueryContext()
    .AddFiltering()
    .AddInstrumentation(options => options.Scopes = builder.Environment.IsDevelopment() ? ActivityScopes.All : ActivityScopes.Default);

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGraphQL();

app.UseHttpsRedirection();

app.Run();