

using SchoolManagement.Domain.SchoolEnums;
using SchoolManagement.Domain.UserManagement;

namespace SchoolManagement.Domain
{
    public class CourseRegistration
    {
        public int Id { get; set; }
        public Courestatus Status { get; set; } = Courestatus.NotRegistered;
        public string? Semester { set; get; }
        public int StudentId { get; set; } // Foreign key
        public Student Student { get; set; } = default!;
        public int CourseId { get; set; } // Foreign key
        public Course Course { get; set; } = default!;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
