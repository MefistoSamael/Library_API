namespace Library.Domain.Models.BookModel
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);

        Task<Book> UpdateAsync(Book book);

        Task DeleteAsync(Book book);

        Task<Book?> GetAsyncById(int bookId);

        Task<Book?> GetAsyncByISBN(string ISBN);

        Task<IEnumerable<Book>> GetPaginatedBooksAsync(int pageNumber, int pageSize);
    }
}
