using FluentValidation;

namespace Library.API.Application.Authors.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator() 
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
