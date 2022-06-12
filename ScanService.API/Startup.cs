using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ScanService.API.Infrastructure;
using ScanService.API.Infrastructure.Interfaces;

namespace ScanService.API;

public class Startup
{
    public void ConfigureServices(IServiceCollection services) 
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Scan API", 
                Description = "Scan Open API. ",
                Contact = new OpenApiContact
                {
                    Name = "Tsypin I.P.",
                    Email = "tsypin.i.p@mail.ru",
                    Url = new Uri("https://t.me/Dedicated407"),
                },
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, "ScanService.Api.xml");
            options.IncludeXmlComments(filePath);
        });
        
        services.AddMediatR(typeof(Startup));
        services.AddControllers();

        services
            .AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("scanDb");
            })
            .AddScoped<IRepository, DataContext>();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseStatusCodePages();

        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapSwagger();
        });
    }
}