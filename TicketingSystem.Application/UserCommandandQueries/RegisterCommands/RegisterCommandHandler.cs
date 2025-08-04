using MediatR;
using TicketingSystem.Application.Interfaces.Coommon;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Enums;
using TicketingSystem.Domain.Exceptions;

namespace TicketingSystem.Application.UserCommandandQueries.RegisterCommands;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtGenerator)
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var exists = await _userRepository.ExistsAsync(request.Email, cancellationToken);
        if (exists)
            throw new NotFoundException("کاربری با چنین  شناسه ای در سیستم ثبت شده است ");

        var user = new User(request.FirstName,
                            request.LastName,
                            request.Email,
                            request.UserRole,
                           BCrypt.Net.BCrypt.HashPassword(request.Password));

        await _userRepository.AddAsync(user ,cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);
        var token = _jwtGenerator.GenerateToken(user);

        return new RegisterCommandResponse
        {
            Token = token,
            Role = user.Role.ToString()
        };
    }
}
