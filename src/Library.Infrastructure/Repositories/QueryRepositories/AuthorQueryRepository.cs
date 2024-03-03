using Azure.Core;
using Dapper;
using Library.Application.Common.Models;
using Library.Application.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Infrastructure.Repositories.QueryRepostirory
{
    public class AuthorQueryRepository : IAuthorQueryRepository
    {
        private string _connectionString = string.Empty;

        public AuthorQueryRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<AuthorDTO> GetAuthorByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

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
                    $"WHERE a.Id = {id}";

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
                    throw new KeyNotFoundException($"Queried object entity was not found, Key: {id}");

                return author;
            }
        }

        public async Task<PaginatedResult<AuthorDTO>> GetPaginatedAuthorsAsync(int pageNumber, int pageSize)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var count = (await connection.QueryAsync<int>("SELECT count(*) from authors")).Single();

                var totalPages = (int)Math.Ceiling(count / (double)pageSize);

                // Because of splitting by BookId, some values in select
                // are repeated
                var sql =
                    "SELECT a.Id as AuthorId, a.Name as AuthorName, " +
                    "b.Id as BookId, b.ISBN, b.Name as BookName, b.Genre, " +
                    "b.Description, b.AuthorId as AuthorId, " +
                    "b.BorrowingTime, b.ReturningTime, a.Name as AuthorName " +
                    "FROM (select Id, Name from authors " +
                    "ORDER BY Id " +
                    $"OFFSET {(pageNumber - 1) * pageSize} ROWS " +
                    $"FETCH NEXT {pageSize} ROWS ONLY) a " +
                    "LEFT JOIN books b " +
                    "ON a.Id = b.AuthorId ";

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

                return new PaginatedResult<AuthorDTO>
                {
                    Collection = authors,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItemCount = count,
                    TotalPageCount = totalPages,
                };
            }
        }
    }
}
