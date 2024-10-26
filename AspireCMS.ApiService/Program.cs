using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.Services;
using AspireCMS.Entities;
using AspireCMS.Interfaces;
using FastEndpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args)
                            .SetupServices();

var app = builder.Build();

app.UseExceptionHandler();

app.UseCors(o =>
{
    o.AllowAnyOrigin();
    o.AllowAnyMethod();
    o.AllowAnyHeader();
});

app.SetupDevelopmentMiddleware();

app.Run();

#region Builder Extensions
public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder SetupServices(this WebApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<CMSContext>("CMS");

        builder.Services.AddFastEndpoints();

        builder.AddServiceDefaults();

        builder.Services.AddCors();

        builder.Services.AddOpenApi();

        builder.Services.AddTransient<IPageService, PageService>();

        builder.Services.AddProblemDetails();

        return builder;
    }
}
#endregion

#region App Extensions
public static class WebApplicationExtensions
{
    public static WebApplication SetupDevelopmentMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.WithTitle("Aspire Content Management System")
                    .WithTheme(ScalarTheme.BluePlanet)
                    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
            });

            app.UseFastEndpoints();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CMSContext>();
                if (context.Database.EnsureCreated())
                {
                    context.Pages.Add(new Page() { Title = "Hello World!", IsPublished = true, Slug = "/" });
                    context.SaveChanges();
                    var page = context.Pages.First();

                    context.ContentBlocks.Add(new ContentBlock() { BlockType = AspireCMS.Enums.BlockType.Text, Content = "Lorem Ipsum", Page = page, PageId = page.PageId, Position = 0 });
                    context.SaveChanges();
                }
            }
        }

        return app;
    }
}
#endregion