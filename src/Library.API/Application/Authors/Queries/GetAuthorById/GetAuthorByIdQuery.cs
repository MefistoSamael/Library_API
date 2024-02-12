using Library.API.Application.Common;
using MediatR;
using Microsoft.Identity.Client;

namespace Library.API.Application.Authors.Queries.GetAuthorById
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
