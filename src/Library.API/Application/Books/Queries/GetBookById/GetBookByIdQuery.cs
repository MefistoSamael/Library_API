using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Queries.GetBookById
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
