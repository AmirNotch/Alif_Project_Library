using Bookify.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

namespace Bookify;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddScoped<IDiscountRepository, DiscountRepository>();

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Alif_Project.API", Version = "v1" });
        });
        
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(Configuration.GetConnectionString("Default"));
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Alif_Project.API v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<NotificationHub>("/notificationHub");
            endpoints.MapControllers();
        });
        
        NotificationHub.OnNotification += (message) =>
        {
            Console.WriteLine($"Received notification: {message}");
        };
    }
}