using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.SchoolManagementDto
{
    public class CourseCreateDto
    {
        // For creating/updating a course
        public class CreateCourseDto
        {
            public string CourseCode { get; set; } = string.Empty;
            public string CourseTitle { get; set; } = string.Empty;
            public int CourseUnit { get; set; }
        }

        //// For reading/displaying course info
        //public class CourseReadDto
        //{
        //    public int Id { get; set; }
        //    public string CourseCode { get; set; } = string.Empty;
        //    public string CourseTitle { get; set; } = string.Empty;
        //    public int CourseUnit { get; set; }
        //}
    }
}
