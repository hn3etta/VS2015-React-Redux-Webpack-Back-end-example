using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BackendStarter.Utilities;

namespace BackendStarter
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOptions();
			services.ConfigureMvc();
			services.AddSignalR();
			services.ConfigureDbContext(Configuration);
			services.ConfigureAuthorization();
			services.ConfigureDependencyInjection();
			services.ConfigureJwtIssuerOptions(Configuration);
			services.ConfigureCors();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseCors("AllowAll");
			app.UseStaticFiles();
			app.ConfigureJwtBearerAuthentication(Configuration);
			app.UseMvc();
			app.ConfigureSignalR();

			Database.Seed(app.ApplicationServices);
		}
	}
}
