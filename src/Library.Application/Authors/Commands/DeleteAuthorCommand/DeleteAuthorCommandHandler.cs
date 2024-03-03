using Library.Application.Common.Exceptions;
using Library.Domain.Models.AuthorModel;
using MediatR;

namespace Library.Application.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorRepository _repository;
        public DeleteAuthorCommandHandler(IAuthorRepository repository) 
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            Author? entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            if (entity.Books.Count != 0)
                throw new DeleteModeRestrictViolation($"There are books beloning to author with name {entity.Name}");
            
            await _repository.DeleteAsync(entity);
        }
    }
}
