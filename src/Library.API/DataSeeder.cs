using Library.Infrastructure;

// Data seeding was done in such way, because
// for GET requests are used different db accesor - Dapper
// and data seeding executed only when was used Ef Core
// so I decided to seed data like this
public class DataSeeder
{
    public static void SeedBooks(LibraryContext context)
    {
        context.Database.EnsureCreated();
        if (!context.Books.Any())
        {
            var books = new List<dynamic>
            {
                new
                {
                    Id = 1,
                    ISBN = "1111111111",
                    Name = "First Book",
                    Genre = "Comedy",
                    Description = "Awesome comedy book",
                    Author = "John Johnson",
                    BorrowingTime = new DateTime(2, 2, 2),
                    ReturningTime = new DateTime(3, 3, 3)
                },
                new
                {
                    Id = 2,
                    ISBN = "2222222222",
                    Name = "Second Book",
                    Genre = "Horror",
                    Description = "Outrageous book",
                    Author = "Karl Young",
                    BorrowingTime = new DateTime(4, 4, 4),
                    ReturningTime = new DateTime(5, 5, 5)
                },
                new
                {
                    Id = 3,
                    ISBN = "333333333",
                    Name = "Third Book",
                    Genre = "Detective",
                    Description = "Brilliant book",
                    Author = "Klara",
                    BorrowingTime = new DateTime(6, 6, 6),
                    ReturningTime = new DateTime(7, 7, 7)
                }
            };
            context.AddRange(books);
            context.SaveChanges();
        }
    }
}