using System;
using System.Text;
using BackendStarter.Hubs;
using BackendStarter.Models;
using BackendStarter.Options;
using BackendStarter.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace BackendStarter.Utilities
{
	public static class StartupExtensions
	{
		private const string SECRET_KEY = "needtogetthisfromenvironment";

		private static readonly SymmetricSecurityKey _signingKey =
			new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

		public static void ConfigureMvc(this IServiceCollection services)
		{
			// Make authentication compulsory across the board (i.e. shut
			// down EVERYTHING unless explicitly opened up).
			services.AddMvc(config =>
			{
				var policy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();

				config.Filters.Add(new AuthorizeFilter(policy));
			});
		}

		public static void ConfigureDbContext(this IServiceCollection services, IConfigurationRoot config)
		{
			services.AddDbContext<BackendStarterContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
			});
		}

		public static void ConfigureAuthorization(this IServiceCollection services)
		{
			services.AddAuthorization(options =>
			{
				options.AddPolicy("BaselineAPI", policy => policy.RequireClaim("BasicAPI", "NormalUser"));
			});
		}

		public static void ConfigureDependencyInjection(this IServiceCollection services)
		{
			services.AddScoped<IAuthorRepo, AuthorRepo>();
			services.AddScoped<ICourseRepo, CourseRepo>();
			services.AddScoped<ICourseOpenRepo, CourseOpenRepo>();
		}

		public static void ConfigureJwtIssuerOptions(this IServiceCollection services, IConfigurationRoot config)
		{
			var jwtOptions = config.GetSection(nameof(JwtIssuerOptions));

			services.Configure<JwtIssuerOptions>(options =>
			{
				options.Issuer = jwtOptions[nameof(JwtIssuerOptions.Issuer)];
				options.Audience = jwtOptions[nameof(JwtIssuerOptions.Audience)];
				options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
			});
		}

		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", policy =>
				{
					policy.WithOrigins(new string[] {
						"http://localhost:3000",
						"http://127.0.0.1:3000"
					});

					policy.AllowAnyMethod();
					policy.AllowCredentials();
					policy.AllowAnyHeader();
				});
			});
		}

		public static void ConfigureJwtBearerAuthentication(this IApplicationBuilder app, IConfigurationRoot config)
		{
			var jwtOptions = config.GetSection(nameof(JwtIssuerOptions));

			app.UseJwtBearerAuthentication(new JwtBearerOptions
			{
				AutomaticAuthenticate = true,
				AutomaticChallenge = true,
				TokenValidationParameters = new TokenValidationParameters
				{
					ClockSkew = TimeSpan.Zero,
					IssuerSigningKey = _signingKey,
					RequireExpirationTime = true,
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateIssuerSigningKey = true,
					ValidateLifetime = true,
					ValidAudience = jwtOptions[nameof(JwtIssuerOptions.Audience)],
					ValidIssuer = jwtOptions[nameof(JwtIssuerOptions.Issuer)]
				}
			});
		}

		public static void ConfigureSignalR(this IApplicationBuilder app)
		{
			app.UseSignalR(routes =>
			{
				routes.MapHub<TestHub>("/testhub");
			});
		}
	}
}
