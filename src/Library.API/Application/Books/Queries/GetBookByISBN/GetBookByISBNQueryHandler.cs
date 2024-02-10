using Dapper;
using Library.Domain.Models.BookModel;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Library.API.Application.Books.Queries.GetBookByISBN
{
    public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, Book>
    {
        private string _connectionString = string.Empty;
        public GetBookByISBNQueryHandler(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<Book> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = $"SELECT * FROM books WHERE books.ISBN = '{request.isbn}'";

                var result = await connection.QuerySingleOrDefaultAsync<Book>(sql);

                if (result is null)
                    throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.isbn}");

                return result;
            }
        }
    }
}
