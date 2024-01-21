using AutoMapper;
using Library.Domain.Model;
using MediatR;

namespace Library.API.Application.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request.Book);

            _bookRepository.Update(book);

            return await _bookRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
