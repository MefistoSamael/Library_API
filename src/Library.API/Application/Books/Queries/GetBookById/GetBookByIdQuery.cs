using Library.API.Application.Common;
using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Queries.GetBookById
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
