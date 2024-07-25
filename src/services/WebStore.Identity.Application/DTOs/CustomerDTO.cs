using System.ComponentModel.DataAnnotations;

namespace WebStore.Identity.Application.DTOs
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
