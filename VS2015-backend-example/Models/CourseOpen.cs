using System;
using System.ComponentModel.DataAnnotations;

namespace BackendStarter.Models
{
    public class CourseOpen
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int Attendees { get; set; }

        public int MaxAttendees { get; set; }
    }

}