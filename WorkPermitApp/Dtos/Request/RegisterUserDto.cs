using WorkPermitApp.Models;

namespace WorkPermitApp.Dtos.Request
{
    public class RegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
