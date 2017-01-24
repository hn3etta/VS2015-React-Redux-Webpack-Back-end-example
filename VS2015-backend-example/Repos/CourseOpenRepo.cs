using System.Collections.Generic;
using System.Linq;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
	public class CourseOpenRepo : ICourseOpenRepo
	{
		BackendStarterContext db;

		public CourseOpenRepo(BackendStarterContext context)
		{
			db = context;
		}

		public OpenCourse Add(OpenCourse openCourse)
		{
			db.OpenCourses.Add(openCourse);
			db.SaveChanges();
			return openCourse;
		}

		public bool Delete(int id)
		{
			var openCourse = db.OpenCourses.Find(id);

			if (openCourse == null)
			{
				return false;
			}

			db.OpenCourses.Remove(openCourse);
			return db.SaveChanges() > 0;
		}

		public bool DeleteAll()
		{
			db.OpenCourses.RemoveRange(db.OpenCourses);
			return db.SaveChanges() > 0;
		}

		public OpenCourse Get(int id)
		{
			return db.OpenCourses.Find(id);
		}

		public IEnumerable<OpenCourse> GetAll()
		{
			return db.OpenCourses.ToList();
		}

		public OpenCourse Save(OpenCourse openCourse)
		{
			db.OpenCourses.Update(openCourse);
			db.SaveChanges();
			return openCourse;
		}
	}
}
