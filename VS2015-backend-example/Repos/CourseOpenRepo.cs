using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendStarter.Models;

namespace BackendStarter.Repos
{
    public class CourseOpenRepo : ICourseOpenRepo
    {
        private List<CourseOpen> _allCoursesOpen;
        private Random _random;

        public CourseOpenRepo()
        {
            _allCoursesOpen = new List<CourseOpen>()
            {
                new CourseOpen()
                {
                    Id = 0,
                    CourseId = 0,
                    Attendees = 5,
                    MaxAttendees = 20
                },
                new CourseOpen()
                {
                    Id = 1,
                    CourseId = 1,
                    Attendees = 8,
                    MaxAttendees = 20
                },
                new CourseOpen()
                {
                    Id = 2,
                    CourseId = 2,
                    Attendees = 19,
                    MaxAttendees = 20
                },
                new CourseOpen()
                {
                    Id = 3,
                    CourseId = 3,
                    Attendees = 2,
                    MaxAttendees = 20
                },
                new CourseOpen()
                {
                    Id = 4,
                    CourseId = 4,
                    Attendees = 13,
                    MaxAttendees = 20
                }
            };

            _random = new Random();
        }

        public IEnumerable<CourseOpen> GetAll()
        {
            return _allCoursesOpen.OrderBy(d => d.Id);
        }

        public CourseOpen Get(int id)
        {
            /* Simulate DB call with a wait */
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();

            var co = _allCoursesOpen.Where(d => d.Id == id).FirstOrDefault();
            co.Attendees = _random.Next(0, co.MaxAttendees);

            return co;
        }

    }
}
