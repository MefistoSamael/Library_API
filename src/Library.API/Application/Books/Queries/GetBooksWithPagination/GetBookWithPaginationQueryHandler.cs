using Dapper;
using Library.Domain.Models.BookModel;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Library.API.Application.Books.Queries.GetBooksWithPagination
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

                var sql = "SELECT * FROM books";

                IEnumerable<Book> books = await connection.QueryAsync<Book>(sql);

                int count = books.Count();


                int totalPages = (int)Math.Ceiling(count / (double)request.pageSize);

                int currentPage = request.pageNumber > totalPages ? totalPages : request.pageNumber;

                IEnumerable<Book> paginatedBooks = books
                    .Skip((currentPage - 1) * request.pageSize)
                    .Take(request.pageSize);


                if (paginatedBooks.Count() == 0)
                    throw new KeyNotFoundException($"There are no queried entities");

                return new BookDTO
                (
                    paginatedBooks,
                    currentPage,
                    totalPages
                );
            }
        }
    }
}
