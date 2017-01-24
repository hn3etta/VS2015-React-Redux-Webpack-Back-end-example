using System.ComponentModel.DataAnnotations;

namespace BackendStarter.Models
{
	public class Author
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(50)]
		public string LastName { get; set; }
	}
}
