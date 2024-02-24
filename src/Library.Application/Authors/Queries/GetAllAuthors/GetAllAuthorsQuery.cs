using Library.Application.Common.Models;
using MediatR;

namespace Library.Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<AuthorDTO>>
    {
        public GetAllAuthorsQuery() { }
    }
}
