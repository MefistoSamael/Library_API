using AutoMapper;
using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request.Book);

            _bookRepository.Add(book);

            return await _bookRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
