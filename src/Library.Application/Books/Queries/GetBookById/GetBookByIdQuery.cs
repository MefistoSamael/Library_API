using Library.Application.Common.Models;
using MediatR;

namespace Library.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public int id;

        public GetBookByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
