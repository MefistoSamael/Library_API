using FluentValidation;
using Library.Domain.Model;

namespace Library.API.Application.Commands.UpdateBookCommand
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        public UpdateBookCommandValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            RuleFor(b => b.Id).NotEmpty();

            RuleFor(b => b.ISBN).NotEmpty()
                .Length(10, 13)
                .MustAsync(BeUniqueISBN)
                    .WithMessage(" '{PropertyName}' must be unique")
                    .WithErrorCode("Unique");

            RuleFor(b => b.Name).NotEmpty();

            RuleFor(b => b.Genre).NotEmpty();

            RuleFor(b => b.Description).NotEmpty();

            RuleFor(b => b.Author).NotEmpty();

            RuleFor(b => b.BorrowingTime).NotEmpty()
                .LessThan(b => b.ReturningTime);
        }

        private async Task<bool> BeUniqueISBN(UpdateBookCommand command, string isbn, CancellationToken cancellationToken)
        {
            Book? book = await _bookRepository.GetAsyncByISBN(isbn);

            //If book exsists with such ISBN, probably it is the same book
            if (book is not null)
                return book.Id == command.Id;
            else
                return true;
        }
    }
}
