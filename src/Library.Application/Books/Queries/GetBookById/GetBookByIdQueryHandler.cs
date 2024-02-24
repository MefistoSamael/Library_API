﻿using Dapper;
using Library.Application.Common.Models;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private string _connectionString = string.Empty;
        public GetBookByIdQueryHandler(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = "SELECT a.Id as AuthorId, a.Name as AuthorName, " +
                    "b.Id as BookId, b.ISBN, b.Name as BookName, b.Genre, " +
                    "b.Description, b.AuthorId as AuthorId, " +
                    "b.BorrowingTime, b.ReturningTime, a.Name as AuthorName " +
                    "FROM books b " +
                    "JOIN authors a ON b.AuthorId = a.Id " +
                    $"WHERE b.Id = {request.id}";

                BookDTO? result = await connection.QuerySingleOrDefaultAsync<BookDTO>(sql);

                if (result is null)
                    throw new KeyNotFoundException($"Queried object entity was not found, Key: {request.id}");

                return result;
            }
        }
    }
}