using System.Collections.Generic;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
	public interface ICourseRepo
	{
		Course Add(Course course);
		bool Delete(int id);
		bool DeleteAll();
		Course Get(int id);
		IEnumerable<Course> GetAll();
		Course Save(Course course);
	}
}
