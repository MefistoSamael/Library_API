using AutoMapper;
using Dapper;
using Library.Application.Common.Models;
using Library.Domain.Models.AuthorModel;
using Library.Domain.Models.BookModel;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDTO>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper) 
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDTO> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAsyncById(request.Id);

            if (author is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            return _mapper.Map<AuthorDTO>(author);
        }
    }
}
