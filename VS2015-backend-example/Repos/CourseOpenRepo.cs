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
            return _allCoursesOpen;
        }

        public CourseOpen Get(int id)
        {
            /* Simulate DB call with a wait */
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();

            var co = _allCoursesOpen.Where(d => d.Id == id).FirstOrDefault();
            co.Attendees = _random.Next(0, co.MaxAttendees);

            return co;
        }

        public bool CourseOpenExists(int courseId)
        {
            return _allCoursesOpen.Where(d => d.CourseId == courseId).Count() > 0;
        }

        public int SetCourseOpen(CourseOpen courseOpen)
        {
            var id = 0;
            if (_allCoursesOpen.Where(d => d.CourseId == courseOpen.CourseId).Count() == 0)
            {
                id = _allCoursesOpen.OrderByDescending(d => d.Id).Select(d => d.Id).FirstOrDefault() + 1;
                _allCoursesOpen.Add(
                    new CourseOpen()
                    {
                        Id = id,
                        CourseId = courseOpen.CourseId,
                        Attendees = courseOpen.Attendees,
                        MaxAttendees = courseOpen.MaxAttendees
                    }
                );
                return id;
            }

            _allCoursesOpen = _allCoursesOpen.Select(d =>
            {
                if (d.CourseId == courseOpen.CourseId)
                {
                    id = courseOpen.Id;
                    d.Attendees = courseOpen.Attendees;
                    d.MaxAttendees = courseOpen.MaxAttendees;
                    return d;
                }

                return d;
            }).ToList();

            return id;
        }

        public bool DeleteCourseOpen(int id)
        {
            if (_allCoursesOpen.Where(d => d.Id == id).Count() == 0)
            {
                return false;
            }

            _allCoursesOpen = _allCoursesOpen.Where(d => d.Id != id).ToList();

            return true;
        }
    }
}
