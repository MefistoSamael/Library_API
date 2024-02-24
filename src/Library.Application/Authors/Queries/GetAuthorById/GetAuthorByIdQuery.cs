using Library.Application.Common.Models;
using MediatR;

namespace Library.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<AuthorDTO>
    {
        public int Id { get; set; }

        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
