var builder = DistributedApplication.CreateBuilder(args);

var webapi = builder.AddProject<Projects.Procat_WebAPI>("webapi");

builder.Build().Run();
