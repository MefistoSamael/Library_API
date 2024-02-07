using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Queries.GetBookByISBN
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
