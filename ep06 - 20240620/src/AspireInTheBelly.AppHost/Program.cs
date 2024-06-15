var builder = DistributedApplication.CreateBuilder(args);

var storage = builder.AddAzureStorage("storage");

var queue = storage.AddQueues("queue");

var apiService = builder.AddProject<Projects.AspireInTheBelly_ApiService>("apiservice");

builder.AddProject<Projects.AspireInTheBelly_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(queue);

builder.Build().Run();
