using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EntityFrameworkHiLoSequence",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturningTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.UniqueConstraint("AK_books_ISBN", x => x.ISBN);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "BorrowingTime", "Description", "Genre", "ISBN", "Name", "ReturningTime" },
                values: new object[,]
                {
                    { 1, "John Johnson", new DateTime(2, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awesome comedy book", "Comedy", "1111111111", "First Book", new DateTime(3, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Karl Young", new DateTime(4, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outrageous book", "Horror", "2222222222", "Second Book", new DateTime(5, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Klara", new DateTime(6, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brilliant book", "Detective", "333333333", "Third Book", new DateTime(7, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_ISBN",
                table: "books",
                column: "ISBN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropSequence(
                name: "EntityFrameworkHiLoSequence");
        }
    }
}
