using System.Collections.Generic;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
    public interface ICourseOpenRepo
    {
        CourseOpen Get(int id);
        IEnumerable<CourseOpen> GetAll();
    }
}