using MediatR;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Application.UserCommandandQueries.RegisterCommands;
public class RegisterCommand : IRequest<RegisterCommandResponse>
{
    public RegisterCommand(string firstName, string lastName, string email, string password, UserRole userRole)
    {
        FirstName=firstName;
        LastName=lastName;
        Email=email;
        Password=password;
        UserRole=userRole;
    }

    public string FirstName { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string Password { get; } = string.Empty;
    public string LastName { get; internal set; }
    public UserRole UserRole { get; internal set; }
}
