using Library.Domain.Models.AuthorModel;
using MediatR;

namespace Library.API.Application.Authors.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _repository;
        public CreateAuthorCommandHandler(IAuthorRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = new Author(request.Name);

            Author createdAuthor = await _repository.AddAsync(author);

            return createdAuthor;
        }
    }
}
