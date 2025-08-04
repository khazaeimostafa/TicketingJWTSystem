using MediatR;
using TicketingSystem.Application.Interfaces.Coommon;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;

namespace TicketingSystem.Application.Tickets.Queries.GetMyTickets;

public class GetMyTicketsQueryHandler : IRequestHandler<GetMyTicketsQuery, List<GetMyTicketsQueryResponse>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ICurrentUser _currentUserService;

    public GetMyTicketsQueryHandler(ITicketRepository ticketRepository, ICurrentUser currentUserService)
    {
        _ticketRepository = ticketRepository;
        _currentUserService = currentUserService;
    }

    public async Task<List<GetMyTicketsQueryResponse>> Handle(GetMyTicketsQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;

        var tickets = await _ticketRepository.GetTicketsByCreatorAsync(userId, cancellationToken);


        var ticketDtos = tickets.Select(t => new GetMyTicketsQueryResponse
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            Status = t.Status.ToString(),
            Priority = t.Priority.ToString(),
            CreatedAt = t.CreatedAt.ToShortDateString(),
            UpdatedAt = t.UpdatedAt.ToShortDateString()
        }).ToList();

        return ticketDtos;
    }
}