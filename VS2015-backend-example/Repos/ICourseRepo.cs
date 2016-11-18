using System.Collections.Generic;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
    public interface ICourseRepo
    {
        int Add(Course newCourse);
        bool Delete();
        bool Delete(int id);
        Course Get(int id);
        IEnumerable<Course> GetAll();
        bool Save(Course updCourse);
    }
}