using SchoolManagement.Domain.UserManagement;


namespace SchoolManagement.Domain
{
    public class College
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
