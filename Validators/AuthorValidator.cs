using BookHubAPI.Models;
using FluentValidation;

namespace BookHubAPI.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Title).NotEmpty().WithMessage("Назва книги є обов'язковою");
            RuleFor(b => b.AuthorId).GreaterThan(0).WithMessage("Потрібно вказати ID автора");
            RuleFor(b => b.Year).InclusiveBetween(1500, DateTime.Now.Year)
                .WithMessage("Рік виходу книги має бути коректним");
        }
    }
}
