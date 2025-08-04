using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Application.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdQuery : IRequest<GetTicketByIdQueryResponse>
    {
        public Guid TicketId { get; }

        public GetTicketByIdQuery(Guid ticketId)
        {
            TicketId=ticketId;
        }
    }
}
