using AutoMapper;
using Library.Application.Common.Models;
using Library.Application.Repositories;
using Library.Domain.Models.AuthorModel;
using MediatR;

namespace Library.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDTO>
    {
        private readonly IAuthorQueryRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAuthorByIdQueryHandler(IAuthorQueryRepository authorRepository, IMapper mapper) 
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDTO> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(request.Id);

            if (author is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            return _mapper.Map<AuthorDTO>(author);
        }
    }
}
