namespace Library.Domain.Models.AuthorModel
{
    public interface IAuthorRepository
    {
        Task<Author> AddAsync(Author author);

        Task<Author> UpdateAsync(Author author);

        Task DeleteAsync(Author author);

        Task<Author?> GetAsyncById(int authorId);
    }
}
