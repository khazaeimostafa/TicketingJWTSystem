using MediatR;

namespace TicketingSystem.Application.UserCommandandQueries.Logins;
public class LoginCommand : IRequest<LoginCommandResponse>
{
    public LoginCommand(string email, string password)
    {
        Email=email;
        Password=password;
    }

    public string Email { get; } = string.Empty;
    public string Password { get; } = string.Empty;
}
