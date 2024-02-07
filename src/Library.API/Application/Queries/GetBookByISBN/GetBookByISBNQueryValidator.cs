using FluentValidation;

namespace Library.API.Application.Queries.GetBookByISBN
{
    public class GetBookByISBNQueryValidator : AbstractValidator<GetBookByISBNQuery>
    {
        public GetBookByISBNQueryValidator()
        {
            RuleFor(q => q.isbn).NotEmpty();
        }
    }
}
