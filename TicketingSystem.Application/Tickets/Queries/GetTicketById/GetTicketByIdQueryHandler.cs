using MediatR;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;

namespace TicketingSystem.Application.Tickets.Queries.GetTicketById;

public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, GetTicketByIdQueryResponse>
{
    private readonly ITicketRepository _ticketRepository;

    public GetTicketByIdQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository=ticketRepository;
    }

    public async Task<GetTicketByIdQueryResponse> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {

        var ticket = await _ticketRepository.GetByIdAsync(request.TicketId, cancellationToken);

        if (ticket == null)
            throw new Exception("Ticket not found.");

        return new GetTicketByIdQueryResponse
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            Status = ticket.Status,
            Priority = ticket.Priority,
            CreatedAt = ticket.CreatedAt,
            UpdatedAt = ticket.UpdatedAt,
            CreatedByUserId = ticket.CreatedByUserId,
            AssignedToUserId = ticket.AssignedToUserId
        };
    }
}