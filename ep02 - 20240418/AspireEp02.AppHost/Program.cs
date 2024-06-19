var builder = DistributedApplication.CreateBuilder(args);

var rabbitMQService = builder.AddRabbitMQ("myqueue")
    .WithManagementPlugin()
    .PublishAsContainer();

var apiService = builder.AddProject<Projects.AspireEp02_ApiService>("apiservice")
    .WithReference(rabbitMQService);

builder.AddProject<Projects.AspireEp02_Web>("webfrontend")
    .WithReference(apiService);

builder.AddProject<Projects.AspireEp02_RabbitMQService>("aspire2024-rabbitmqservice")
    .WithReference(rabbitMQService);

builder.Build().Run();
