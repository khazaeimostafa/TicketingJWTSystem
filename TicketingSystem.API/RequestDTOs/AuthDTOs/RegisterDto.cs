using TicketingSystem.Domain.Enums;

namespace TicketingSystem.API.RequestDTOs.AuthDTOs
{
    public class RegisterDto
    {

        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserRole UserRole { get; set; } = UserRole.Employee;
    }
}
