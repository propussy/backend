var builder = DistributedApplication.CreateBuilder(args);

var psql = builder.AddPostgres("psql")
    .WithDataVolume()
    .AddDatabase("user-module");

var minio = builder.AddMinioContainer("minio")
    .WithDataVolume();

builder.AddProject<Projects.Procat_WebAPI>("webapi")
    .WaitFor(psql)
    .WithReference(psql)
    .WaitFor(minio)
    .WithReference(minio);

builder.Build().Run();
