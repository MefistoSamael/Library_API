using AutoMapper;
using Dapper;
using Library.Application.Common.Models;
using Library.Domain.Models.AuthorModel;
using Library.Domain.Models.BookModel;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsyncById(request.id);

            if (book is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.id}");

            return _mapper.Map<BookDTO>(book);
        }
    }
}
