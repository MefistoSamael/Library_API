using FluentValidation;

namespace Library.API.Application.Queries.GetBooksWithPagination
{
    public class GetBookWithPaginationQueryValidator : AbstractValidator<GetBooksWithPaginationQuery>
    {
        public GetBookWithPaginationQueryValidator()
        {
            RuleFor(q => q.pageNumber).GreaterThan(0);

            RuleFor(q => q.pageSize).GreaterThan(0);
        }
    }
}
