using System.Collections.Generic;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
	public interface ICourseOpenRepo
	{
		OpenCourse Add(OpenCourse openCourse);
		bool Delete(int id);
		bool DeleteAll();
		OpenCourse Get(int id);
		IEnumerable<OpenCourse> GetAll();
		OpenCourse Save(OpenCourse openCourse);
	}
}
