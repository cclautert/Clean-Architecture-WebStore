using System.ComponentModel.DataAnnotations;

namespace WebStore.Identity.Application.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "The {0} is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
