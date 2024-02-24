using Dapper;
using Library.Application.Common.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Books.Queries.GetBooksWithPagination
{
    public class GetBookWithPaginationQueryHandler : IRequestHandler<GetBooksWithPaginationQuery, PaginatedResult<BookDTO>>
    {
        private string _connectionString = string.Empty;
        public GetBookWithPaginationQueryHandler(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<PaginatedResult<BookDTO>> Handle(GetBooksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = "SELECT a.Id as AuthorId, a.Name as AuthorName, " +
                    "b.Id as BookId, b.ISBN, b.Name as BookName, b.Genre, " +
                    "b.Description, b.AuthorId as AuthorId, " +
                    "b.BorrowingTime, b.ReturningTime, a.Name as AuthorName " +
                    "FROM books b " +
                    "JOIN authors a ON b.AuthorId = a.Id";

                IEnumerable<BookDTO> books = await connection.QueryAsync<BookDTO>(sql);

                int count = books.Count();


                int totalPages = (int)Math.Ceiling(count / (double)request.pageSize);

                int currentPage = request.pageNumber > totalPages ? totalPages : request.pageNumber;

                IEnumerable<BookDTO> paginatedBooks = books
                    .Skip((currentPage - 1) * request.pageSize)
                    .Take(request.pageSize);


                if (paginatedBooks.Count() == 0)
                    throw new KeyNotFoundException($"There are no queried entities");

                return new PaginatedResult<BookDTO>
                {
                    collection = paginatedBooks,
                    currentPage = currentPage,
                    totalPages = totalPages
                };
            }
        }
    }
}
