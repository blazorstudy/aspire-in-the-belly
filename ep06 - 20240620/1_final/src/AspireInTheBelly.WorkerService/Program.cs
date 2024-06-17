using AspireInTheBelly.WorkerService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddAzureQueueClient("queue");
builder.AddAzureTableClient("table");

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
