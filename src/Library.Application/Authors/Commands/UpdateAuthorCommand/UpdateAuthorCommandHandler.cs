using AutoMapper;
using Library.Application.Common.Models;
using Library.Domain.Models.AuthorModel;
using MediatR;

namespace Library.Application.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorDTO>
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) 
        {
            _repository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDTO> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author? entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            var updatedAuthor = await _repository.UpdateAsync(_mapper.Map<Author>(request));

            return _mapper.Map<AuthorDTO>(updatedAuthor);
        }
    }
}
