using FluentValidation;

namespace Library.Application.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator() 
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
