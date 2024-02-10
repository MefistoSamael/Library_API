using Library.API.Application.Exceptions;
using Library.Domain.Models.AuthorModel;
using Library.Domain.SeedWork;
using MediatR;

namespace Library.API.Application.Authors.Commands.DeleteAuthorCommand
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
            Author? entity = await _repository.GetAsyncById(request.Id);

            if (entity is null)
                throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

            if (entity.Books.Count != 0)
                throw new DeleteModeRestrictViolation($"There are books beloning to author with name {entity.Name}");
            
            await _repository.DeleteAsync(entity);
        }
    }
}
