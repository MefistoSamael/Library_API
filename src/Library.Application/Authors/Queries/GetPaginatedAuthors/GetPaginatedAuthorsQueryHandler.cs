using AutoMapper;
using Library.Application.Common.Models;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Authors.Queries.GetPaginatedAuthors
{
    public class GetPaginatedAuthorsQueryHandler : IRequestHandler<GetPaginatedAuthorsQuery, PaginatedResult<AuthorDTO>>
    {
        private readonly IAuthorQueryRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetPaginatedAuthorsQueryHandler(IAuthorQueryRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<AuthorDTO>> Handle(GetPaginatedAuthorsQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AuthorDTO> authors = await _authorRepository.GetPaginatedAuthorsAsync(request.PageNumber, request.PageSize);

            return authors;
        }
    }
}
