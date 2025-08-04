using FluentValidation;

namespace TicketingSystem.Application.UserCommandandQueries.Logins;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("ایمیل نمی‌تواند خالی باشد.")
            .EmailAddress().WithMessage("فرمت ایمیل معتبر نیست.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("رمز عبور نمی‌تواند خالی باشد.")
            .MinimumLength(6).WithMessage("رمز عبور باید حداقل ۶ کاراکتر باشد.");
    }
}