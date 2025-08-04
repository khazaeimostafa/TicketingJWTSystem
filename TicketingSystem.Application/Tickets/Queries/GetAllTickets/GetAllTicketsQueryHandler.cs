using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Application.Interfaces.Coommon;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;
using TicketingSystem.Application.Tickets.Queries.GetMyTickets;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Application.Tickets.Queries.GetAllTickets;
public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<GetAllTicketsQueryResponse>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ICurrentUser _currentUserService;

    public GetAllTicketsQueryHandler(ITicketRepository ticketRepository, ICurrentUser currentUserService)
    {
        _ticketRepository=ticketRepository;
        _currentUserService=currentUserService;
    }

    public async Task<List<GetAllTicketsQueryResponse>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _ticketRepository.GetAllAsync(cancellationToken);


        var ticketDtos = tickets.Select(t => new GetAllTicketsQueryResponse
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
