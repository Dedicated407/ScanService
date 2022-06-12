using MediatR;
using Microsoft.EntityFrameworkCore;
using ScanService.API.Infrastructure;
using ScanService.API.Infrastructure.Interfaces;

namespace ScanService.API;

public class Startup
{
    public void ConfigureServices(IServiceCollection services) 
    {
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
        app.UseStatusCodePages();

        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}