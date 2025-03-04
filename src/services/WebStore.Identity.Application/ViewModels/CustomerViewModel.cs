﻿using System.ComponentModel.DataAnnotations;

namespace WebStore.Identity.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "Field {0} is mandatory")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Field {0} is mandatory")]
        [StringLength(14, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Field {0} is mandatory")]
        [EmailAddress(ErrorMessage = "Field {0} is in an invalid format")]
        public string? Email { get; set; }

        public string? Address { get; set; }
    }

    public class CustomerIdViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field {0} is mandatory")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Field {0} is mandatory")]
        [StringLength(14, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Field {0} is mandatory")]
        [EmailAddress(ErrorMessage = "Field {0} is in an invalid format")]
        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
