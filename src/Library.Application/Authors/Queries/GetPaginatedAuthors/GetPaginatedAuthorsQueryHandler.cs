using AutoMapper;
using Dapper;
using Library.Application.Common.Models;
using Library.Domain.Models.AuthorModel;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Authors.Queries.GetPaginatedAuthors
{
    public class GetPaginatedAuthorsQueryHandler : IRequestHandler<GetPaginatedAuthorsQuery, PaginatedResult<AuthorDTO>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetPaginatedAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<AuthorDTO>> Handle(GetPaginatedAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetPaginatedAuthors(request.PageNumber, request.PageSize);

            IEnumerable<AuthorDTO> paginatedAuthors = _mapper.Map<IEnumerable<AuthorDTO>>(authors);

            return new PaginatedResult<AuthorDTO>
            {
                collection = paginatedAuthors,
                currentPage = request.PageNumber,
            };
        }
    }
}
