using AutoMapper;
using Dapper;
using Library.Application.Common.Models;
using Library.Domain.Models.BookModel;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace Library.Application.Books.Queries.GetBooksWithPagination
{
    public class GetBookWithPaginationQueryHandler : IRequestHandler<GetBooksWithPaginationQuery, PaginatedResult<BookDTO>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookWithPaginationQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<BookDTO>> Handle(GetBooksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetPaginatedBooksAsync(request.pageNumber, request.pageSize);

            var booksDTO = _mapper.Map<IEnumerable<BookDTO>>(books);

            return new PaginatedResult<BookDTO>
            { 
                collection = booksDTO,
                currentPage = request.pageNumber,
            };

        }
    }
}
