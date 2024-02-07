using FluentValidation;

namespace Library.API.Application.Queries.GetBookById
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(q => q.id).NotEmpty();
        }
    }
}
