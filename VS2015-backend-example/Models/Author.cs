using System.ComponentModel.DataAnnotations;

namespace BackendStarter.Models
{
    public class Author
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }

}