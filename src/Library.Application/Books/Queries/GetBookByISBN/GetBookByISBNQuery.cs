using Library.Application.Common.Models;
using MediatR;

namespace Library.Application.Books.Queries.GetBookByISBN
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
