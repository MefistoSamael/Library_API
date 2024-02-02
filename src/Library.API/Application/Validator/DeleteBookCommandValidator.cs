using FluentValidation;
using Library.API.Application.Commands;

namespace Library.API.Application.Validator
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator() 
        {
            RuleFor(b => b.Id).NotEmpty();
        }
    }
}
