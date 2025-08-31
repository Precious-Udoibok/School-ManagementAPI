

using SchoolManagement.Domain.SchoolEnums;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain.SchoolManagementDto
{
    public class LecturerRegistrationDto
    {
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public Gender Gender { set; get; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format.")]
        public required string Email { set; get; }
        public string? PasswordHash { set; get; }
    }
}
