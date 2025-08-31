using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain;
using SchoolManagement.Domain.SchoolManagementDto;
using SchoolManagement.Persistence;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        //this is for calling the database
        private readonly SchoolManagementDbContext _context;

        public CollegeController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        //Create operation
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<College>> CreateCollege(CollegeCreateDto dto)

        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var college = new College
            {
                Name = dto.Name
            };

            //Add to database
            await _context.Colleges.AddAsync(college);

            await _context.SaveChangesAsync();

            // Return 201 Created with the new college info
            return Ok(new { Message = "College Created Successfully." });
        }


        //Fetch by id
        [HttpGet("id")]
        [Authorize]
        public async Task<ActionResult<College>> GetCollegeById(int id)
        {

            var college = await _context.Colleges.FindAsync(id);
            if (college == null)
            {
                return NotFound();
            }

            return college;
        }


        //Fetch all
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<College>>> GetAllCollege()
        {
            return await _context.Colleges.ToListAsync();
        }

        //Update operation
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateCollege(int id, CollegeCreateDto dto)
        {
            try
            {
                var collegeExists = await _context.Colleges.FindAsync(id);

                if (collegeExists == null)
                {
                    return NotFound();
                }

                //_context.Entry(college).State = EntityState.Modified;
                collegeExists.Name = dto.Name;


                await _context.SaveChangesAsync();

            } catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            } catch (InvalidOperationException)
            {
                return BadRequest();
            }


            return Ok(new { Message = "College Updated Successfully." });
        }

        //DELETE Operation
        [HttpDelete("id")]
        [Authorize]
        public async Task<IActionResult> DeleteCollege(int id)
        {
            var college = await _context.Colleges.FindAsync(id);
            if (college == null)
            {
                return NotFound(new { message = $"College with id {id} doesn't exist", status = 999 });
            }
            _context.Colleges.Remove(college);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "College Deleted Successfully." });
        }
    }
}
