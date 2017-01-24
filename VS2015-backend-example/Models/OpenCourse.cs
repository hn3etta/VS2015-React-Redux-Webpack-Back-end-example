using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendStarter.Models
{
	public class OpenCourse
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public int Attendees { get; set; }

		[Required]
		public int MaxAttendees { get; set; }

		// Relationships

		[Required]
		[ForeignKey("CourseId")]
		public int CourseId { get; set; }
	}
}
