using Library.Domain.Models.AuthorModel;
using MediatR;

namespace Library.API.Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<AuthorDTO>>
    {
        public GetAllAuthorsQuery() { }
    }
}
