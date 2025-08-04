using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Application.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommandResponse
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketPriority Priority { get; set; }
    }
}
