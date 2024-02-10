using FluentValidation;
using Library.Domain.Models.AuthorModel;

namespace Library.API.Application.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(b => b.Id).NotEmpty();
        }
    }
}
