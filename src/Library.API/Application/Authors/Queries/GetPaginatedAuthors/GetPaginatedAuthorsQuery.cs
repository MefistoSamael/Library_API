using Library.API.Application.Common;
using MediatR;

namespace Library.API.Application.Authors.Queries.GetPaginatedAuthors
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
