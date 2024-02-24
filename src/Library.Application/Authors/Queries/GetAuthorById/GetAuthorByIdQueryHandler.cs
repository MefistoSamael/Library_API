using Dapper;
using Library.Application.Common.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDTO>
    {
        private readonly string _connectionString;
        public GetAuthorByIdQueryHandler(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ??
                throw new ArgumentNullException(nameof(_connectionString));
        }
        public async Task<AuthorDTO> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Because of splitting by BookId, some values in select
                // are repeated
                var sql =
                    "SELECT a.Id as AuthorId, a.Name as AuthorName, " +
                    "b.Id as BookId, b.ISBN, b.Name as BookName, b.Genre, " +
                    "b.Description, b.AuthorId as AuthorId, " +
                    "b.BorrowingTime, b.ReturningTime, a.Name as AuthorName " +
                    "FROM authors a " +
                    "LEFT JOIN books b " +
                    "ON a.Id = b.AuthorId " +
                    $"WHERE a.Id = {request.Id}";

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

                AuthorDTO? author = authorsDict.Values.SingleOrDefault();

                if (author is null)
                    throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.Id}");

                return author;
            }
        }
    }
}
