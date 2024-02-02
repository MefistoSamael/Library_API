using FluentValidation;
using Library.API.Application.Commands;

namespace Library.API.Application.Validator
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator() 
        {
            RuleFor(b => b.ISBN).NotEmpty().Length(10, 13);
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Genre).NotEmpty();
            RuleFor(b => b.Description).NotEmpty();
            RuleFor(b => b.Author).NotEmpty();
            RuleFor(b => b.BorrowingTime).NotEmpty().LessThan(b => b.ReturningTime);
        }
    }
}
