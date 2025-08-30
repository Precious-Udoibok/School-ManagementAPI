

using SchoolManagement.Domain.SchoolEnums;
using SchoolManagement.Domain.UserManagement;

namespace SchoolManagement.Domain
{
    public class CourseRegistration

    {
        public int Id { get; set; }
        public string? Semester { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
