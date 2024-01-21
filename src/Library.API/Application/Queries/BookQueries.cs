using Dapper;
using Microsoft.Data.SqlClient;

namespace Library.API.Application.Queries
{
    public class BookQueries : IBookQueries
    {
        private string _connectionString = String.Empty;
        public BookQueries(string connectionString) 
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }
        public async Task<IEnumerable<BookDTO>?> GetAllBooksAsync()
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();

                return await connection.QueryAsync<BookDTO>(@"SELECT * FROM books");
            }
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = (await connection.QueryAsync<BookDTO>(@$"SELECT * FROM books WHERE books.id = {id}")).SingleOrDefault();

                if (result is null)
                    throw new KeyNotFoundException();

                return result;
            }
        }

        public async Task<BookDTO> GetBookByISBNAsync(string ISBN)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = (await connection.QueryAsync<BookDTO>(@$"SELECT * FROM books WHERE books.ISBN = '{ISBN}'")).SingleOrDefault();

                if (result is null )
                    throw new KeyNotFoundException();

                return result;
            }
        }
    }
}
