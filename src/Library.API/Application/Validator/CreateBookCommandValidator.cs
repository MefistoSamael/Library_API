﻿using FluentValidation;
using Library.API.Application.Commands;
using Library.Domain.Model;
using Library.Infrastructure.Repositories;

namespace Library.API.Application.Validator
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandValidator(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;

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

        private async Task<bool> BeUniqueISBN(CreateBookCommand command, string isbn, CancellationToken cancellationToken)
        {
            Book? book = await _bookRepository.GetAsyncByISBN(isbn);

            if (book is not null)
                return false;
            
            return true;
        }
    }
}
