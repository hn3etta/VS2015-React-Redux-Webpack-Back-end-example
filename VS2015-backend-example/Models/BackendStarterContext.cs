using Microsoft.EntityFrameworkCore;

namespace BackendStarter.Models
{
	public class BackendStarterContext : DbContext
	{
		public BackendStarterContext() { }

		public BackendStarterContext(DbContextOptions<BackendStarterContext> options)
			: base(options) { }

		public DbSet<Author> Authors { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<OpenCourse> OpenCourses { get; set; }
	}
}
