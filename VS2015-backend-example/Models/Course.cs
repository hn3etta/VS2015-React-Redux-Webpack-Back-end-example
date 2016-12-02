using System.ComponentModel.DataAnnotations;

namespace BackendStarter.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string WatchHref { get; set; }

        [Required]
        public string Length { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public bool IsOpen { get; set; }
    }

}