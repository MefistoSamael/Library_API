namespace Library.Domain.Models.BookModel
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);

        Task<Book> UpdateAsync(Book book);

        Task DeleteAsync(Book book);

        Task<Book?> GetByIdAsync(int bookId);

        Task<Book?> GetByISBNAsync(string ISBN);
    }
}
