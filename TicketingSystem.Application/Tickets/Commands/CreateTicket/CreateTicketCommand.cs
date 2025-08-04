using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Application.Tickets.Commands.CreateTicket;
public record CreateTicketCommand : IRequest<CreateTicketCommandResponse>
{
    public CreateTicketCommand(
    string title,
    string description,
    TicketPriority priority)
    {
        this.Title=title;
        this.Description=description;
        this.Priority=priority;
    }

    public string Title { get; }
    public string Description { get; }
    public TicketPriority Priority { get; }
}