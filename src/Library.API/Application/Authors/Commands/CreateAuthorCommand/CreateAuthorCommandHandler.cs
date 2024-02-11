using AutoMapper;
using Library.API.Application.Common;
using Library.Domain.Models.AuthorModel;
using MediatR;

namespace Library.API.Application.Authors.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorDTO>
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public async Task<AuthorDTO> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = _mapper.Map<Author>(request);

            Author createdAuthor = await _repository.AddAsync(author);

            return _mapper.Map<AuthorDTO>(createdAuthor);
        }
    }
}
