using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Domain.SchoolManagementDto;
using SchoolManagement.Domain.UserManagement;
using SchoolManagement.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //this is for calling the database
        private readonly SchoolManagementDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(SchoolManagementDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        //Implement register enpoint
        //Validate Input
        //ChECK IF THE Email already exist in the db
        //create the user object
        // Hash Password
        //Save User to db
        //return success message

        //Implement register enpoint
        [HttpPost("register/student")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterStudent([FromBody] UserRegistrationDto UserDto)
        {

            //Validate Input
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Check if the email and password are provide
            var isUserExist = await _context.Students.AnyAsync(em => em.Email == UserDto.Email);

            if (isUserExist)
            {
                return BadRequest("Email is already in use");
            }

            //Create User Object
            var user_student = new Student
            {
                Firstname = UserDto.Firstname,
                Lastname = UserDto.Lastname,
                Email = UserDto.Email,
                Gender = UserDto.Gender,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(UserDto.PasswordHash)
            };

            //Add to the db set
            _context.Students.Add(user_student);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Student Account Registered successfully.", StudentId = user_student.Id });
        }


        [HttpPost("register/lecturer")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterLecturer([FromBody] LecturerRegistrationDto LecturerUserDto)
        {

            //Validate Input
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Check if the email and password are provide
            var isLecturerUserExist = await _context.Lecturer.AnyAsync(em => em.Email == LecturerUserDto.Email);

            if (isLecturerUserExist)
            {
                return BadRequest("Email is already in use");
            }

            //Create User Object
            var user_lecturer = new Lecturer
            {
                FirstName = LecturerUserDto.FirstName,
                LastName = LecturerUserDto.LastName,
                Email = LecturerUserDto.Email,
                Gender = LecturerUserDto.Gender,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(LecturerUserDto.PasswordHash)
            };

            //Add to the db set
            _context.Lecturer.Add(user_lecturer);
            await _context.SaveChangesAsync();
            return Ok(new { Message = " Account Registered successfully.", StudentId = user_lecturer.Id });
        }


        //Implement register enpoint
        //Check if the email and password are provide
        //Find the user by email in the db
        // Optional check if the account is suspended
        //generate token - define expireation time

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginDto LoginRequest)
        {
            //Check if the email and password are provide
            if (string.IsNullOrEmpty(LoginRequest.Email) || string.IsNullOrEmpty(LoginRequest.Password))
            {
                return BadRequest("Email and password are required");

            }

            //Find the user by email in the db
            //this retun a bool
            var isLoginUserExist = await _context.Students.AnyAsync(em => em.Email == LoginRequest.Email);

            //Get the actual value for student 
            var user_student = await _context.Students.FirstOrDefaultAsync(em => em.Email == LoginRequest.Email);

            if (user_student == null)
            {
                return Unauthorized("Invalid Email or Password");
            }

            if (!VerifyPassword(LoginRequest.Password, user_student.PasswordHash!))
            {
                return Unauthorized("Invalid Email or Password");

            }

            //Create a private method to generate a string
            var token = GenerateJwtToken(user_student);

            return Ok(new LoginResponseDto
            {
                Token = token,
                Email = user_student.Email,
                Role = user_student.Role,
                Id = user_student.Id
            });

        }

        private string GenerateJwtToken(Student user)
        {
            //claim
            //1.Attach the user id to the name identifier in the claim
            // attach user email to the claim
            // attach the user firstname to the claim name
            // Attach the account type to the role in the claim
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (ClaimTypes.Email, user.Email),
                new Claim (ClaimTypes.Name, user.Firstname),
                new Claim (ClaimTypes.GivenName, $"{user.Firstname} {user.Lastname}")
            };

            //keys
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (_configuration["key"]));

            //Credential
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Assign the claims, the key, creds to the token
            var token = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                audience: _configuration["Audience"],
                claims: claims,
                signingCredentials: creds,
                //define expiration time
                expires: DateTime.Now.AddHours(2));

            //Final is JwtSecurity token Handler that create the token of strings
            var newToken = new JwtSecurityTokenHandler().WriteToken(token);

            return newToken;
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash))
            {
                return false;
            }

            var ispasswordValid = BCrypt.Net.BCrypt.Verify(password, storedHash);

            return ispasswordValid;
        }

        // return a messsage(token)

        //Go to user controller and protect enpoint
    }
}
