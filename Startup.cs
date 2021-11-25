namespace api;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options => options.UseNamespaceRouteToken());
        services.AddEndpointsApiExplorer();
        services.AddOpenApiDocument(cfg => 
        {
            cfg.UseApiEndpoints();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
        app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();
        
        app.UseOpenApi();
        app.UseSwaggerUi3();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}