using MediatR;
using TicketingSystem.Application.Interfaces.Coommon;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Application.Tickets.Commands.CreateTicket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, CreateTicketCommandResponse>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ICurrentUser _currentUser;

    public CreateTicketCommandHandler(ICurrentUser currentUser, ITicketRepository ticketRepository)
    {
        _currentUser = currentUser;
        _ticketRepository=ticketRepository;
    }

    public async Task<CreateTicketCommandResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket(request.Title, request.Description, request.Priority, _currentUser.UserId);
        await _ticketRepository.AddAsync(ticket, cancellationToken);
        await _ticketRepository.SaveChangesAsync(cancellationToken);

        return new CreateTicketCommandResponse { Title = ticket.Title, Priority = ticket.Priority, Description  = ticket.Description };
    }
}