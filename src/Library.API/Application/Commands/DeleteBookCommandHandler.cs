using AutoMapper;
using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request.Book);

            _bookRepository.Delete(book);

            return await _bookRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
