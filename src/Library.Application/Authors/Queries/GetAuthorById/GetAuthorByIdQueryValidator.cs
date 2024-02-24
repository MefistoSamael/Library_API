using FluentValidation;

namespace Library.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator() 
        {
            RuleFor(q => q.Id);
        }
    }
}
