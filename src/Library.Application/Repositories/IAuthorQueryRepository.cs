using Library.Application.Common.Models;

namespace Library.Application.Repositories
{
    public interface IAuthorQueryRepository
    {
        Task<PaginatedResult<AuthorDTO>> GetPaginatedAuthorsAsync(int pageNumber, int pageSize);

        Task<AuthorDTO> GetAuthorByIdAsync(int id);
    }
}
