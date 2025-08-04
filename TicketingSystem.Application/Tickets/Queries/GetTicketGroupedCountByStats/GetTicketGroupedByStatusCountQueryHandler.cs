using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Application.Tickets.Queries.GetTicketGroupedCountByStats;
public class GetTicketGroupedByStatusCountQueryHandler : IRequestHandler<GetTicketGroupedByStatusCountQuery, GetTicketGroupedByStatusCountQueryResponse>
{
    private readonly ITicketRepository _ticketRepository;

    public GetTicketGroupedByStatusCountQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository=ticketRepository;
    }

    public async Task<GetTicketGroupedByStatusCountQueryResponse> Handle(GetTicketGroupedByStatusCountQuery request, CancellationToken cancellationToken)
    {

        return await _ticketRepository.GetTicketsStatsAsync(cancellationToken);



    }
}

