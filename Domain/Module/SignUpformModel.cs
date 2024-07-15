using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Required namespace for data annotations
using System.ComponentModel.DataAnnotations;

namespace CommonModel.Module
{
    // Model class for the sign-up form
    public class SignUpformModel
    {
        // Primary key for the SignUpformModel
        [Key]
        public int Id { get; set; }

        // First name of the user
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        // Last name of the user
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        // Email address of the user
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        // Password for the user's account
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Password must be at least 5 characters long.")]
        public string Password { get; set; }

        // Confirmation of the password
        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // Terms acceptance checkbox
        [Required(ErrorMessage = "You must accept the terms and conditions.")]
        public bool TermsAccepted { get; set; }
    }
}
