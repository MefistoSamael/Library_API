using Library.Application.Common.Models;

namespace Library.Application.Repositories
{
    public interface IBookQueryRepository
    {
        Task<PaginatedResult<BookDTO>> GetPaginatedBooksAsync(int pageNumber, int pageSize);

        Task<BookDTO> GetBookByIdAsync(int id);

        Task<BookDTO> GetBookByISBNAsync(string isbn);
    }
}
