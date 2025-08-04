using MediatR;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;
using TicketingSystem.Domain.Exceptions;

namespace TicketingSystem.Application.Tickets.Commands.UpdateTicket;
public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, UpdateTicketCommandResponse>
{
    private readonly ITicketRepository _ticketRepository;

    public UpdateTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository=ticketRepository;
    }

    public async Task<UpdateTicketCommandResponse> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetByIdAsync(request.TicketId, cancellationToken);
        if (ticket == null)
            throw new NotFoundException("تیکت یافت نشد");

        ticket.UpdateStatus(request.Status);
        ticket.AssignToAdmin(Guid.Parse(request.AssignedToUserId.ToString()));
        ticket.UpdatedAtTime();
        await _ticketRepository.SaveChangesAsync(cancellationToken);

        return new UpdateTicketCommandResponse { AssignedTo = ticket.AssignedToUserId, Description = ticket.Description , Priority = ticket.Priority , Title = ticket.Title };
    }
}
