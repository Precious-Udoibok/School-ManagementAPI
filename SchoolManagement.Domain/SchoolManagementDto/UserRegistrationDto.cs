using SchoolManagement.Domain.SchoolEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.SchoolManagementDto
{
    public class UserRegistrationDto
    {
        public required string Firstname { set; get; }
        public required string Lastname { set; get; }
        public Gender Gender { set; get; }
        public string? PasswordHash { set; get; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format.")]
        public required string Email { set; get; }
    }
}
