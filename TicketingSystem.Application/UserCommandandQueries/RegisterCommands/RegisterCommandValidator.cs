using FluentValidation;

namespace TicketingSystem.Application.UserCommandandQueries.RegisterCommands;
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("نام نمی‌تواند خالی باشد.")
            .MaximumLength(100).WithMessage("نام نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("نام خانوادگی نمی‌تواند خالی باشد.")
            .MaximumLength(100).WithMessage("نام خانوادگی نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("ایمیل الزامی است.")
            .EmailAddress().WithMessage("فرمت ایمیل معتبر نیست.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("رمز عبور الزامی است.")
            .MinimumLength(6).WithMessage("رمز عبور باید حداقل ۶ کاراکتر باشد.")
            .Matches("[A-Z]").WithMessage("رمز عبور باید حداقل یک حرف بزرگ داشته باشد.")
            .Matches("[a-z]").WithMessage("رمز عبور باید حداقل یک حرف کوچک داشته باشد.")
            .Matches("[0-9]").WithMessage("رمز عبور باید حداقل یک رقم داشته باشد.");
    }
}
