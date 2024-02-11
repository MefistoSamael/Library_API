using FluentValidation;

namespace Library.API.Application.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator() 
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
