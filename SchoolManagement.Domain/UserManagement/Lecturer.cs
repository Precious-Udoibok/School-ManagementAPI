using SchoolManagement.Domain.SchoolEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.UserManagement
{
    public class Lecturer
    {
        public int Id { set; get; }
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public Gender Gender { set; get; }
        public Role Role { set; get; } = Role.Lecturer;
        public UserStatus Userstatus { set; get; } = UserStatus.Active;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format.")]
        public required string Email {set; get;}
        public int? CollegeId { get; set; }   // Foreign key
        public College? College { get; set; } = default!; // Navigation property
        public string? PasswordHash { set; get; }
    }
}
