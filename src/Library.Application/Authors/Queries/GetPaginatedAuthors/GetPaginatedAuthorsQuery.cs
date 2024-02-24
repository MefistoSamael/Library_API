using Library.Application.Common.Models;
using MediatR;

namespace Library.Application.Authors.Queries.GetPaginatedAuthors
{
    public class GetPaginatedAuthorsQuery : IRequest<PaginatedResult<AuthorDTO>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public GetPaginatedAuthorsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
