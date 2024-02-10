using Library.Domain.Models.BookModel;
using MediatR;

namespace Library.API.Application.Books.Queries.GetBookByISBN
{
    public class GetBookByISBNQuery : IRequest<Book>
    {
        public string isbn;

        public GetBookByISBNQuery(string isbn)
        {
            this.isbn = isbn;
        }
    }
}
