using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("sql01")
                 .WithDataVolume()
                 .AddDatabase("CMS");

var apiService = builder.AddProject<Projects.AspireCMS_ApiService>("apiservice")
                    .WithReference(sql)
                    .WithExternalHttpEndpoints();

//var frontend = builder.AddNpmApp("frontend", "../AspireCMS.FrontEnd", "dev")
//    .WithReference(apiService)
//    .WithReference(cache)
//    .WithHttpEndpoint(env: "PORT")
//    .WithExternalHttpEndpoints()
//    .PublishAsDockerFile();

builder.Build().Run();
