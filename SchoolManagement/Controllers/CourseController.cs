using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain;
using SchoolManagement.Domain.SchoolManagementDto;
using SchoolManagement.Persistence;
using static SchoolManagement.Domain.SchoolManagementDto.CourseCreateDto;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //this is for calling the database
        private readonly SchoolManagementDbContext _context;

        public CourseController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        //Create operation
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCollege(CreateCourseDto dto)

        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = new Course
            {
                CourseCode = dto.CourseCode,
                CourseTitle = dto.CourseTitle,
                CourseUnit = dto.CourseUnit
            };

            //Add to database
            await _context.Courses.AddAsync(course);

            await _context.SaveChangesAsync();

            // Return 201 Created with the new college info
            return Ok(new { Message = "Course Created Successfully." });
        }


        //Fetch by id
        [HttpGet("id")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {

            var course1 = await _context.Courses.FindAsync(id);
            if (course1 == null)
            {
                return NotFound();
            }

            return course1;
        }


        //Fetch all
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCollege()
        {
            return await _context.Courses.ToListAsync();
        }

        //Update operation
        [HttpPut]
        public async Task<ActionResult> UpdateCourse(int id, CreateCourseDto dto)
        {
            try
            {
                var courseExists = await _context.Courses.FindAsync(id);

                if (courseExists == null)
                {
                    return NotFound();
                }

                //_context.Entry(college).State = EntityState.Modified;
                courseExists.CourseTitle = dto.CourseTitle;
                courseExists.CourseUnit = dto.CourseUnit;
                courseExists.CourseCode = dto.CourseCode;


                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }


            return Ok(new { Message = "Course Updated Successfully." });
        }

        //DELETE Operation
        [HttpDelete("id")]

        public async Task<IActionResult> DeleteCollege(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound(new { message = $"College with id {id} doesn't exist", status = 999 });
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Course Deleted Successfully." });
        }
    }
}
