using FluentValidation;

namespace Library.API.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(q => q.id).NotEmpty();
        }
    }
}
