using BookHubAPI.Models;
using FluentValidation;

namespace BookHubAPI.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Ім'я автора є обов'язковим");
            RuleFor(a => a.Country).NotEmpty().WithMessage("Країна автора є обов'язковою");
        }
    }
}
