using AutoMapper;
using Library.Application.Common.Models;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Books.Queries.GetBooksWithPagination
{
    public class GetBookWithPaginationQueryHandler : IRequestHandler<GetBooksWithPaginationQuery, PaginatedResult<BookDTO>>
    {
        private readonly IBookQueryRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookWithPaginationQueryHandler(IBookQueryRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<BookDTO>> Handle(GetBooksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetPaginatedBooksAsync(request.pageNumber, request.pageSize);

            return books;
        }
    }
}
