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
        public string? Name { set; get; }
        public Gender Gender { set; get; }
        public UserStatus Userstatus { set; get; } = UserStatus.Active;
        public required string Email {set; get;}
        public int CollegeId { get; set; }   // Foreign key
        public College College { get; set; } = default!; // Navigation property
        public string? PasswordHash { set; get; }
    }
}
