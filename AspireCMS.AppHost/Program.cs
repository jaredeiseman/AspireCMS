using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("sql01")
                 .WithDataVolume()
                 .AddDatabase("CMS");

var apiService = builder.AddProject<Projects.AspireCMS_ApiService>("apiservice")
                    .WithReference(sql)
                    .WithExternalHttpEndpoints();

var client = builder.AddNpmApp("client", "../AspireCMS.Client", "dev")
    .WithReference(apiService)
    .WithReference(cache)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
