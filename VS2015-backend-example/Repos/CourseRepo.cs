using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
    public class CourseRepo : ICourseRepo
    {
        private List<Course> _allCourses;
        private readonly ICourseOpenRepo _courseOpenRepo;

        public CourseRepo(ICourseOpenRepo SignupsRepo)
        {
            _courseOpenRepo = SignupsRepo;
            _allCourses = new List<Course>()
            {

                new Course()
                {
                    Id = 0,
                    AuthorId = 0,
                    Title = "Building Applications in React and Flux",
                    WatchHref = "http://www.pluralsight.com/courses/react-flux-building-applications",
                    Category = "JavaScript",
                    Length = "5:08"
                },
                new Course()
                {
                    Id = 1,
                    AuthorId = 0,
                    Title = "Clean Code: Writing Code for Humans",
                    WatchHref = "http://www.pluralsight.com/courses/writing-clean-code-humans",
                    Category = "Software Practices",
                    Length = "3:10"
                },
                new Course()
                {
                    Id = 2,
                    AuthorId = 0,
                    Title = "Architecting Applications for the Real World",
                    WatchHref = "http://www.pluralsight.com/courses/architecting-applications-dotnet",
                    Category = "Software Architecture",
                    Length = "2:52"
                },
                new Course()
                {
                    Id = 3,
                    AuthorId = 0,
                    Title = "Becoming an Outlier: Reprogramming the Developer Mind",
                    WatchHref = "http://www.pluralsight.com/courses/career-reboot-for-developer-mind",
                    Category = "Career",
                    Length = "2:30"
                },
                new Course()
                {
                    Id = 4,
                    AuthorId = 0,
                    Title = "Web Component Fundamentals",
                    WatchHref = "http://www.pluralsight.com/courses/web-components-shadow-dom",
                    Category = "HTML5",
                    Length = "5:10"
                }
            };
        }

        public IEnumerable<Course> GetAll()
        {
            return _allCourses.Select(x => {
                if (_courseOpenRepo.CourseOpenExists(x.Id)) {
                    x.IsOpen = true;
                } else {
                    x.IsOpen = false;
                }
                return x;
            });
        }

        public Course Get(int id)
        {
            var course = _allCourses.Where(c => c.Id == id).FirstOrDefault();

            if(course != null)
            {
                course.IsOpen = _courseOpenRepo.CourseOpenExists(course.Id);
            }

            return course;
        }

        public int Add(Course newCourse)
        {
            int newId = _allCourses.OrderByDescending(c => c.Id).Select(c => c.Id).FirstOrDefault() + 1;
            newCourse.Id = newId;
            _allCourses.Add(newCourse);

            return newId;
        }

        public bool Save(Course updCourse)
        {
            var currCourse = _allCourses.Where(c => c.Id == updCourse.Id).FirstOrDefault();
            if (currCourse != null)
            {
                currCourse.AuthorId = updCourse.AuthorId;
                currCourse.Title = updCourse.Title;
                currCourse.WatchHref = updCourse.WatchHref;
                currCourse.Category = updCourse.Category;
                currCourse.Length = updCourse.Length;
                return true;
            }

            return false;
        }

        public bool Delete()
        {
            _allCourses.Clear();

            return true;
        }

        public bool Delete(int id)
        {
            var delCourse = _allCourses.Where(c => c.Id == id).FirstOrDefault();
            if (delCourse != null)
            {
                _allCourses.Remove(delCourse);
                _courseOpenRepo.DeleteCourseOpenByCourseId(id);
                return true;
            }

            return false;
        }

    }
}
