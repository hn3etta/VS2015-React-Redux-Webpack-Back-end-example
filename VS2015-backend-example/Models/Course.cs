using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendStarter.Models
{
	public class Course
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Title { get; set; }

		[Required]
		[MaxLength(200)]
		public string WatchHref { get; set; }

		[Required]
		[MaxLength(5)]
		public string Length { get; set; }

		[Required]
		[MaxLength(50)]
		public string Category { get; set; }

		[NotMapped]
		public bool IsOpen
		{
			get
			{
				return OpenCourse != null;
			}
		}

		// Relationships

		[Required]
		public int AuthorId { get; set; }

		[ForeignKey("AuthorId")]
		public Author Author { get; set; }

		public OpenCourse OpenCourse { get; set; }
	}
}
