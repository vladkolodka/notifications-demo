using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo.ApiServer
{
    using Infrastructure.Data;
	using Microsoft.EntityFrameworkCore;
    using Notifications.Hubs;
    using Notifications.Interfaces;
    using Notifications.Services;
    using Notifications.Workers;

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
			services.AddDbContext<AppDataContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
					builder => builder.MigrationsAssembly(typeof(AppDataContext).Assembly.GetName().Name)));

			services.AddSignalR();

			services.AddTransient<INotificationConsumer, RabbitMqNotificationConsumer>();
			services.AddScoped<INotificationHandler, BasicNotificationHandler>();
			services.AddHostedService<NotificationConsumerWorker>();

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(builder =>
			{
				// TODO
				builder.WithOrigins("http://localhost:3000")
					.AllowAnyHeader()
					.WithMethods("GET", "POST")
					.AllowCredentials();
			});

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHub<NotificationHub>("/hub/notifications");
			});
		}
	}
}