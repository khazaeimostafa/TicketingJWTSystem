using MediatR;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;

namespace TicketingSystem.Application.Tickets.Commands.DeleteTicket;
public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, bool>
{
    private readonly ITicketRepository _ticketRepository;

    public DeleteTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetByIdAsync(request.TicketId, cancellationToken);
        if (ticket == null)
            return false;

        await _ticketRepository.DeleteAsync(request.TicketId, cancellationToken);
        await _ticketRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
