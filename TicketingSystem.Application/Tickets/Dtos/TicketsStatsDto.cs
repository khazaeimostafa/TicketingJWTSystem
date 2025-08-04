using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Application.Tickets.Dtos
{
    public class TicketsStatsDto
    {
        public int OpenCount { get; set; }
        public int InProgressCount { get; set; }
        public int ClosedCount { get; set; }
    }
}
