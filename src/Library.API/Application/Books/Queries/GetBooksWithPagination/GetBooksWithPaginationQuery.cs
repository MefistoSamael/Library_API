using MediatR;

namespace Library.API.Application.Books.Queries.GetBooksWithPagination
{
    public class GetBooksWithPaginationQuery : IRequest<BookDTO>
    {
        public int pageSize;

        public int pageNumber;

        public GetBooksWithPaginationQuery(int pageSize, int pageNumber)
        {
            this.pageSize = pageSize;
            this.pageNumber = pageNumber;
        }
    }
}
