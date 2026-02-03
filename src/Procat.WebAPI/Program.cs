using Procat.WebAPI.Configuration;

LoggingConfiguration.CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureLogging();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
