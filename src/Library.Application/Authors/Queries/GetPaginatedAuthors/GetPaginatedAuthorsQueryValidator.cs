using FluentValidation;

namespace Library.Application.Authors.Queries.GetPaginatedAuthors
{
    public class GetPaginatedAuthorsQueryValidator : AbstractValidator<GetPaginatedAuthorsQuery>
    {
        public GetPaginatedAuthorsQueryValidator() 
        {
            RuleFor(q => q.PageNumber).GreaterThan(0).NotEmpty();
            RuleFor(q => q.PageSize).GreaterThan(0).NotEmpty();
        }
    }
}
