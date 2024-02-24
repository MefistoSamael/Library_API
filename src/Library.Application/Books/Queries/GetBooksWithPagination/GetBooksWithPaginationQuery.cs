using Library.Application.Common.Models;
using MediatR;

namespace Library.Application.Books.Queries.GetBooksWithPagination
{
    public class GetBooksWithPaginationQuery : IRequest<PaginatedResult<BookDTO>>
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
