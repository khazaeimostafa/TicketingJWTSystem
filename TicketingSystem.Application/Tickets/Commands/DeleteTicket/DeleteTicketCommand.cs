using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Application.Tickets.Commands.DeleteTicket;
public class DeleteTicketCommand : IRequest<bool>
{

    public Guid TicketId { get; }

    public DeleteTicketCommand(Guid ticketId)
    {
        TicketId=ticketId;
    }
};
