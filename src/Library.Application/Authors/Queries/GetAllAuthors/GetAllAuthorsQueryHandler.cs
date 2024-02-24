using Dapper;
using Library.Application.Common.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorDTO>>
    {
        private readonly string _connectionString;

        public GetAllAuthorsQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(_connectionString));
        }
        public async Task<IEnumerable<AuthorDTO>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
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
                    "ON a.Id = b.AuthorId";

                // This whole tricky construction was created, to
                // extract distinct authors with their books
                Dictionary<int,AuthorDTO> authorsDict = new Dictionary<int, AuthorDTO>();

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
                if (authors.Count() == 0)
                    throw new KeyNotFoundException($"There are no queried entities");

                return authors;
            }
        }
    }
}
