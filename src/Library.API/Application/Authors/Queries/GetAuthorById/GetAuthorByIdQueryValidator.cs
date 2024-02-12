using FluentValidation;
using Library.API.Application.Books.Queries.GetBookById;

namespace Library.API.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator() 
        {
            RuleFor(q => q.Id);
        }
    }
}
