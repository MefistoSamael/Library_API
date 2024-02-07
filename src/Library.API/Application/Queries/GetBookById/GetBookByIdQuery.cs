using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int id;

        public GetBookByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
