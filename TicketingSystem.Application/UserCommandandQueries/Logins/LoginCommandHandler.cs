using MediatR;
using TicketingSystem.Application.Interfaces.Coommon;

namespace TicketingSystem.Application.UserCommandandQueries.Logins;
public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtGenerator;

    public LoginCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtGenerator)
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user == null)
            throw new UnauthorizedAccessException("ایمیل یا رمز عبور اشتباه است.");

        bool passwordMatchess = BCrypt.Net.BCrypt.Verify("Admin212345", "$2a$11$w3A2Qhpe260LHasnY8ydseEDigp4mZMtwHTlSC4GfjnvjMCh3/2GK");
        bool passwordMatches = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!passwordMatches)
            throw new UnauthorizedAccessException("ایمیل یا رمز عبور اشتباه است.");


        var token = _jwtGenerator.GenerateToken(user);

        return new LoginCommandResponse { Token = token, Role = user.Role.ToString() };
    }
}

