using System.Collections.Generic;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
    public interface ICourseOpenRepo
    {
        IEnumerable<CourseOpen> GetAll();

        CourseOpen Get(int id);

        bool CourseOpenExists(int id);

        int SetCourseOpen(CourseOpen courseOpen);

        bool DeleteCourseOpen(int id);
    }
}