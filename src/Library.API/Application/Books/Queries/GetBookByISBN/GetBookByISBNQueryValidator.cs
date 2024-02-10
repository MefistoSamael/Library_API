using FluentValidation;

namespace Library.API.Application.Books.Queries.GetBookByISBN
{
    public class GetBookByISBNQueryValidator : AbstractValidator<GetBookByISBNQuery>
    {
        public GetBookByISBNQueryValidator()
        {
            RuleFor(q => q.isbn).NotEmpty();
        }
    }
}
