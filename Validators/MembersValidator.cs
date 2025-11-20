using FluentValidation;
using BookHubAPI.Models;

namespace BookHubAPI.Validators
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Ім'я обов’язкове.")
                .Length(2, 50).WithMessage("Ім’я має містити від 2 до 50 символів.");

            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("Електронна пошта обов’язкова.")
                .EmailAddress().WithMessage("Некоректний формат електронної пошти.");

            RuleFor(m => m.Role)
                .IsInEnum().WithMessage("Некоректна роль користувача.");
        }
    }
}
