using FluentValidation;

namespace Library.API.Application.Books.Queries.GetBooksWithPagination
{
    public class GetBookWithPaginationQueryValidator : AbstractValidator<GetBooksWithPaginationQuery>
    {
        public GetBookWithPaginationQueryValidator()
        {
            RuleFor(q => q.pageNumber).GreaterThan(0).NotEmpty();

            RuleFor(q => q.pageSize).GreaterThan(0).NotEmpty();
        }
    }
}
