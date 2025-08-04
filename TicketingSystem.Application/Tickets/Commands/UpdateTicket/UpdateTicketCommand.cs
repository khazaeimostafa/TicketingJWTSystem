using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Application.Tickets.Commands.UpdateTicket;
public class UpdateTicketCommand : IRequest<UpdateTicketCommandResponse>
{
    public UpdateTicketCommand(Guid ticketId, TicketStatus status, Guid assignedToUserId)
    {
        TicketId=ticketId;
        Status=status;
        AssignedToUserId=assignedToUserId;
    }

    public Guid TicketId { get; }
    public TicketStatus Status { get; }
    public Guid AssignedToUserId { get; }
}

