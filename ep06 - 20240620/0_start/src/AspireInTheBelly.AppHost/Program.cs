var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireInTheBelly_ApiService>("apiservice");

builder.AddProject<Projects.AspireInTheBelly_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
