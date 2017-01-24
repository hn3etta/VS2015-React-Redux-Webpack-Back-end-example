using System.Collections.Generic;
using System.Linq;
using BackendStarter.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendStarter.Repos
{
	public class CourseRepo : ICourseRepo
	{
		BackendStarterContext db;

		public CourseRepo(BackendStarterContext context, ICourseOpenRepo SignupsRepo)
		{
			db = context;
		}

		public Course Add(Course course)
		{
			db.Courses.Add(course);
			db.SaveChanges();
			return course;
		}

		public bool Delete(int id)
		{
			var course = db.Courses
				.Include(c => c.OpenCourse)
				.FirstOrDefault(c => c.Id == id);

			if (course == null)
			{
				return false;
			}

			db.Remove(course);
			return db.SaveChanges() > 0;
		}

		public bool DeleteAll()
		{
			db.Courses.RemoveRange(db.Courses);
			return db.SaveChanges() > 0;
		}

		public Course Get(int id)
		{
			return db.Courses
				.Include(c => c.OpenCourse)
				.FirstOrDefault(c => c.Id == id);
		}

		public IEnumerable<Course> GetAll()
		{
			return db.Courses
				.Include(c => c.OpenCourse)
				.ToList();
		}

		public Course Save(Course course)
		{
			db.Courses.Update(course);
			db.SaveChanges();
			return course;
		}
	}
}
