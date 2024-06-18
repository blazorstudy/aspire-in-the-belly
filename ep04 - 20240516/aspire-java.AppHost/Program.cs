using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

//var apiService = builder.AddProject<Projects.aspire_java_ApiService>("apiservice");

var javaService = builder.AddContainer("aspire-weather", "aspire-weather", "0.0.1")
                        .WithHttpEndpoint(name: "http", port: 8080, targetPort: 8080)
                        .WithOtlpExporter();
   
var frontend = builder.AddProject<Projects.aspire_java_Web>("webfrontend")
                        .WithExternalHttpEndpoints()
                        .WithReference(javaService.GetEndpoint("http"));

builder.Build().Run();
