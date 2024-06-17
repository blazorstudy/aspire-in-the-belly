var builder = DistributedApplication.CreateBuilder(args);

var storage = builder.AddAzureStorage("storage");

var queue = storage.AddQueues("queue");
var table = storage.AddTables("table");

var apiService = builder.AddProject<Projects.AspireInTheBelly_ApiService>("apiservice");

builder.AddProject<Projects.AspireInTheBelly_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(queue)
    .WithReference(table);

builder.AddProject<Projects.AspireInTheBelly_WorkerService>("workerservice")
       .WithReference(queue)
       .WithReference(table);

builder.Build().Run();
