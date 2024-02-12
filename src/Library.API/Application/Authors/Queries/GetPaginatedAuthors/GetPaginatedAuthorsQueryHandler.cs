using Library.API.Application.Common;
using MediatR;
using Dapper;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Library.API.Application.Authors.Queries.GetPaginatedAuthors
{
    public class GetPaginatedAuthorsQueryHandler : IRequestHandler<GetPaginatedAuthorsQuery, PaginatedResult<AuthorDTO>>
    {
        private readonly string _connectionString;

        public GetPaginatedAuthorsQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(_connectionString));
        }

        public async Task<PaginatedResult<AuthorDTO>> Handle(GetPaginatedAuthorsQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //Getting all authors

                // Because of splitting by BookId, some values in select
                // are repeated
                var sql =
                    "SELECT a.Id as AuthorId, a.Name as AuthorName, " +
                    "b.Id as BookId, b.ISBN, b.Name as BookName, b.Genre, " +
                    "b.Description, b.AuthorId as AuthorId, " +
                    "b.BorrowingTime, b.ReturningTime, a.Name as AuthorName " +
                    "FROM authors a " +
                    "LEFT JOIN books b " +
                    "ON a.Id = b.AuthorId";

                // This whole tricky construction was created, to
                // extract distinct authors with their books
                Dictionary<int, AuthorDTO> authorsDict = new Dictionary<int, AuthorDTO>();

                await connection.QueryAsync<AuthorDTO, BookDTO, AuthorDTO>
                    (sql, (authorDTO, bookDTO) =>
                    {
                        if (!authorsDict.TryGetValue(authorDTO.AuthorId, out AuthorDTO? authorEntry))
                        {
                            authorEntry = authorDTO;
                            authorEntry.Books = new List<BookDTO>();
                            authorsDict.Add(authorEntry.AuthorId, authorEntry);
                        }

                        authorEntry.Books.Add(bookDTO);

                        return authorEntry;
                    }, splitOn: "BookId");

                IEnumerable<AuthorDTO> authors = authorsDict.Values;


                // Getting paginated authors
                int count = authors.Count();
                if (count == 0)
                    throw new KeyNotFoundException($"There are no queried entities");

                int totalPages = (int)Math.Ceiling(count / (double)request.PageSize);

                int currentPage = request.PageNumber > totalPages ? totalPages : request.PageNumber;

                authors = authors.Skip((currentPage - 1) * request.PageSize)
                    .Take(request.PageSize);

                return new PaginatedResult<AuthorDTO>
                {
                    collection = authors,
                    currentPage = currentPage,
                    totalPages = totalPages
                };
            }
        }
    }
}
