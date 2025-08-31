

using SchoolManagement.Domain.SchoolEnums;

namespace SchoolManagement.Domain.SchoolManagementDto
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public int Id { get; set; }
    }
}
