using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Application.Tickets.Commands.DeleteTicket;

internal class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
{
    public DeleteTicketCommandValidator()
    {
        RuleFor(x => x.TicketId)
            .NotEmpty().WithMessage("شناسه تیکت نباید خالی باشد.");
    }
}