using Library.API.Application.Common;
using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Queries.GetBookByISBN
{
    public class GetBookByISBNQuery : IRequest<BookDTO>
    {
        public string isbn;

        public GetBookByISBNQuery(string isbn)
        {
            this.isbn = isbn;
        }
    }
}
