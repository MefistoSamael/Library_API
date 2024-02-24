using FluentValidation;

namespace Library.Application.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(b => b.Id).NotEmpty();
        }
    }
}
