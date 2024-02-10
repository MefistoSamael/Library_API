using Library.Domain.Models.AuthorModel;
using Library.Domain.Models.BookModel;
using Library.Infrastructure;

// Data seeding was done in such way, because
// for GET requests are used different db accesor - Dapper
// and data seeding executed only when was used Ef Core
// so I decided to seed data like this
public class DataSeeder
{
    public static void SeedDB(LibraryContext context)
    {
        context.Database.EnsureCreated();
        if (!context.Authors.Any())
        {
            var authors = new List<Author>
            {
                new Author("John Johnson"),
                new Author("Karl Young"),
                new Author("Klara"),
            };
            context.AddRange(authors);
            context.SaveChanges();
        }
        if (!context.Books.Any())
        {
            var books = new List<dynamic>
            {
                new Book
                (
                      "1111111111",
                    "First Book",
                    "Comedy",
                    "Awesome comedy book",
                    context.Authors.Where(a => a.Name == "John Johnson").First().Id,
                    new DateTime(2, 2, 2),
                    new DateTime(3, 3, 3)
                ),
                new Book
                (
                      "2222222222",
                    "Second Book",
                    "Horror",
                    "Outrageous book",
                    context.Authors.Where(a => a.Name == "Karl Young").First().Id,
                    new DateTime(4, 4, 4),
                    new DateTime(5, 5, 5)
                ),
                new Book
                (
                     "3333333333",
                    "Third Book",
                    "Detective",
                    "Brilliant book",
                    context.Authors.Where(a => a.Name == "Klara").First().Id,
                    new DateTime(6, 6, 6),
                    new DateTime(7, 7, 7)
                ),
                new Book
                (
                     "4444444444",
                    "Forth Book",
                    "Detective",
                    "Superb book",
                    context.Authors.Where(a => a.Name == "Klara").First().Id,
                    new DateTime(7, 7, 7),
                    new DateTime(8, 8, 8)
                )
            };
            context.AddRange(books);
            context.SaveChanges();
        }
    }
}