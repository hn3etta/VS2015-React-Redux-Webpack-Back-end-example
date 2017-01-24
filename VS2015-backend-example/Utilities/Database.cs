using System;
using System.Collections.Generic;
using System.IO;
using BackendStarter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Linq;

namespace BackendStarter.Utilities
{
	public static class Database
	{
		public static void Seed(IServiceProvider serviceProvider)
		{
			using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<BackendStarterContext>();

				context.Database.Migrate();

				if (!context.Authors.Any())
				{
					context.SeedAuthors();
				}

				if (!context.Courses.Any())
				{
					context.SeedCourses();
				}

				if (!context.OpenCourses.Any())
				{
					context.SeedOpenCourses();
				}
			}
		}

		private static void SeedAuthors(this BackendStarterContext context)
		{
			var json = File.ReadAllText(@"SeedData\authors.json");
			var data = JsonConvert.DeserializeObject<IEnumerable<Author>>(json);
			context.AddRange(data);
			context.SaveChanges();
		}

		private static void SeedCourses(this BackendStarterContext context)
		{
			var json = File.ReadAllText(@"SeedData\courses.json");
			var data = JsonConvert.DeserializeObject<IEnumerable<Course>>(json);
			context.AddRange(data);
			context.SaveChanges();
		}

		private static void SeedOpenCourses(this BackendStarterContext context)
		{
			var json = File.ReadAllText(@"SeedData\open-courses.json");
			var data = JsonConvert.DeserializeObject<IEnumerable<OpenCourse>>(json);
			context.AddRange(data);
			context.SaveChanges();
		}
	}
}
