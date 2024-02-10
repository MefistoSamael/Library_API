using Dapper;
using Library.Domain.Models.BookModel;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Library.API.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private string _connectionString = string.Empty;
        public GetBookByIdQueryHandler(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = $"SELECT * FROM books WHERE books.id = {request.id}";

                Book? result = await connection.QuerySingleOrDefaultAsync<Book>(sql);

                if (result is null)
                    throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.id}");

                return result;
            }
        }
    }
}
