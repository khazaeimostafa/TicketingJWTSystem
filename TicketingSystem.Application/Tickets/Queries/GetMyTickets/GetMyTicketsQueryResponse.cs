using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Application.Tickets.Queries.GetMyTickets
{
    public class GetMyTicketsQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Priority { get; set; } = default!;
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

    }
}
