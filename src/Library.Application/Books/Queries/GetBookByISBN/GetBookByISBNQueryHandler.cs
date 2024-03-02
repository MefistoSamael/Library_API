﻿using AutoMapper;
using Dapper;
using Library.Application.Common.Models;
using Library.Domain.Models.BookModel;
using Library.Domain.SeedWork;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Books.Queries.GetBookByISBN
{
    public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, BookDTO>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookByISBNQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsyncByISBN(request.isbn);

            if (book is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.isbn}");

            return _mapper.Map<BookDTO>(book);
        }
    }
}
