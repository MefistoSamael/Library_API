using Dapper;
using Library.Application.Common.Models;
using Library.Application.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Infrastructure.Repositories.QueryRepositories
{
    public class BookQueryRepository : IBookQueryRepository
    {
        private string _connectionString = string.Empty;

        public BookQueryRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }
        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = "SELECT a.Id as AuthorId, a.Name as AuthorName, " +
                    "b.Id as BookId, b.ISBN, b.Name as BookName, b.Genre, " +
                    "b.Description, b.AuthorId as AuthorId, " +
                    "b.BorrowingTime, b.ReturningTime, a.Name as AuthorName " +
                    "FROM books b " +
                "JOIN authors a ON b.AuthorId = a.Id " +
                    $"WHERE b.Id = {id}";

                BookDTO? result = await connection.QuerySingleOrDefaultAsync<BookDTO>(sql);

                if (result is null)
                    throw new KeyNotFoundException($"Queried object entity was not found, Key: {id}");

                return result;
            }
        }

        public async Task<BookDTO> GetBookByISBNAsync(string isbn)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = "SELECT a.Id as AuthorId, a.Name as AuthorName, " +
                    "b.Id as BookId, b.ISBN, b.Name as BookName, b.Genre, " +
                    "b.Description, b.AuthorId as AuthorId, " +
                    "b.BorrowingTime, b.ReturningTime, a.Name as AuthorName " +
                    "FROM books b " +
                    "JOIN authors a ON b.AuthorId = a.Id " +
                    $"WHERE b.ISBN = {isbn}";

                var result = await connection.QuerySingleOrDefaultAsync<BookDTO>(sql);

                if (result is null)
                    throw new KeyNotFoundException($"Queried object entity was not found, Key: {isbn}");

                return result;
            }
        }

        public async Task<PaginatedResult<BookDTO>> GetPaginatedBooksAsync(int pageNumber, int pageSize)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var count = (await connection.QueryAsync<int>("SELECT count(*) from books")).Single();

                var totalPages = (int)Math.Ceiling(count / (double)pageSize);

                var sql = "SELECT a.Id as AuthorId, a.Name as AuthorName, " +
                    "b.Id as BookId, b.ISBN, b.Name as BookName, b.Genre, " +
                    "b.Description, b.AuthorId as AuthorId, " +
                    "b.BorrowingTime, b.ReturningTime, a.Name as AuthorName " +
                    "FROM books b " +
                    "JOIN authors a ON b.AuthorId = a.Id " +
                    "ORDER BY BookId " +
                    $"OFFSET {(pageNumber - 1) * pageSize} ROWS " +
                    $"FETCH NEXT {pageSize} ROWS ONLY";

                IEnumerable<BookDTO> books = await connection.QueryAsync<BookDTO>(sql);

                PaginatedResult<BookDTO> result = new PaginatedResult<BookDTO>
                {
                    Collection = books,
                    CurrentPage = pageNumber,
                    TotalItemCount = count,
                    TotalPageCount = totalPages,
                    PageSize = pageSize
                };


                return result;
            }
        }
    }
}
