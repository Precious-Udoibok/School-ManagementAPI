namespace SchoolManagement.Domain
{
    public class Course
    {
        public int Id { set; get; }
        public string? CourseCode { set; get; }
        public string? CourseTitle { set; get; }
        public int? CourseUnit { set; get; }
        public List<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();

    }
}
