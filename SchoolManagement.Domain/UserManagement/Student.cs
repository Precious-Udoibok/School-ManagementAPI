using SchoolManagement.Domain.SchoolEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.UserManagement
{
    public class Student
    {
        public int Id { set; get; }
        public required string Firstname { set; get; }
        public required string Lastname { set; get; }
        public Gender Gender { set; get; }
        public string? PasswordHash { set; get; }
        public int CollegeId { get; set; }   // Foreign key
        public College College { get; set; } = default!; // Navigation property
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format.")]
        public required string Email { set; get; }
        public UserStatus UserStatus { set; get; } = UserStatus.Active;
        public List<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();

    }
}
