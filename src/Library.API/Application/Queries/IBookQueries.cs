namespace Library.API.Application.Queries
{
    public interface IBookQueries
    {
        Task<BookDTO> GetBookByIdAsync(int id);

        Task<BookDTO> GetBookByISBNAsync(string ISBN);

        Task<IEnumerable<BookDTO>?> GetAllBooksAsync();
    }
}
