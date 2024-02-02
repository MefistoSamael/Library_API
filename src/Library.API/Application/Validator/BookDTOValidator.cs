using FluentValidation;
using Library.API.Application.Queries;

namespace Library.API.Application.Validator
{
    public class BookDTOValidator : AbstractValidator<BookDTO>
    {
        public BookDTOValidator() 
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
