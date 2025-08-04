using FluentValidation;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;

namespace TicketingSystem.Application.Tickets.Commands.CreateTicket;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    private readonly ITicketRepository _ticketRepository;
    public CreateTicketCommandValidator(ITicketRepository ticketRepository)
    {
        _ticketRepository=ticketRepository;

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("عنوان نمی‌تواند خالی باشد.")
            .MaximumLength(100)
            .MustAsync(UniqueTitle).WithMessage("تیکتی با این عنوان قبلاً ثبت شده است.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("توضیح الزامی است.");

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage("اولویت نامعتبر است.");


    }

    private async Task<bool> UniqueTitle(string title, CancellationToken cancellationToken)
    {
        return !await _ticketRepository.ExistsWithTitleAsync(title, cancellationToken);
    }
}
