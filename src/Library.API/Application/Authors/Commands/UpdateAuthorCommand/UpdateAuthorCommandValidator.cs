﻿using FluentValidation;

namespace Library.API.Application.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator() 
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
