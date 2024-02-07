using Dapper;
using Library.Domain.Model;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Library.API.Application.Queries.GetBooksWithPagination
{
    public class GetBookWithPaginationQueryHandler : IRequestHandler<GetBooksWithPaginationQuery, BookDTO>
    {
        private string _connectionString = string.Empty;
        public GetBookWithPaginationQueryHandler(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<BookDTO> Handle(GetBooksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                IEnumerable<Book> books = await connection.QueryAsync<Book>(@"SELECT * FROM books");

                int count = books.Count();

                int totalPages = (int)Math.Ceiling(count / (double)request.pageSize);

                int currentPage = request.pageNumber > totalPages ? totalPages : request.pageNumber;

                return new BookDTO
                (
                    books
                    .Skip((currentPage - 1) * request.pageSize)
                    .Take(request.pageSize),
                    currentPage,
                    totalPages
                );
            }
        }
    }
}
