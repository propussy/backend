using FastEndpoints;
using FastEndpoints.Swagger;
using Procat.UsersModule;
using Procat.WebAPI.Configuration;
using Scalar.AspNetCore;

LoggingConfiguration.CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.ConfigureLogging();

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
    };
});

builder.Services.AddUsersModule(config);

builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();

app.UseExceptionHandler();
app.UseFastEndpoints();
app.UseOpenApi(c => c.Path = "/openapi/{documentName}.json");
app.MapScalarApiReference();

app.Run();
