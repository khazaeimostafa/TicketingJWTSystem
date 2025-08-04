using FluentValidation;
using TicketingSystem.Application.Interfaces.Coommon;

namespace TicketingSystem.Application.Tickets.Commands.UpdateTicket;
public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
{

    private readonly IUserRepository _userRepository;
    public UpdateTicketCommandValidator(IUserRepository userRepository)
    {
        _userRepository=userRepository;

        RuleFor(x => x.TicketId)
            .NotEmpty().WithMessage("شناسه تیکت نمی‌تواند خالی باشد.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("وضعیت انتخاب‌شده معتبر نیست.");

        RuleFor(x => x.AssignedToUserId)
            .NotEmpty().WithMessage("شناسه کاربر مسئول نمی‌تواند خالی باشد.");

        RuleFor(x => x.AssignedToUserId)
          .NotNull().WithMessage("عنوان نمی‌تواند خالی باشد.")

          .MustAsync(MustBeAdmin).WithMessage("کاریر باید در نقش ادمین باشد");
    }

    private async Task<bool> MustBeAdmin(Guid userId, CancellationToken cancellationToken)
    {
        return (await _userRepository.ISAdmin(userId, cancellationToken));
    }
}