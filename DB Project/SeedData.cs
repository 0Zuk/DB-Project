using DbProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
       
        if (!context.authors.Any())
        {
            context.authors.AddRange(
                new Author { Name = "Devran bulduk" },
                new Author { Name = "Pontan kalle" },
                new Author { Name = "Donald trump" },
                new Author { Name = "Joe biden" }
            );
            context.SaveChanges(); 
        }

        if (!context.books.Any())
        {
            context.books.AddRange(
                new Book { Titel = "Harry harmynt den 3dje", PublishedYear = "1899", genre = "facts" },
                new Book { Titel = "tom the trigger", PublishedYear = "2023", genre = "Fantasy" },
                new Book { Titel = "The styler", PublishedYear = "1957", genre = "factual" },
                new Book { Titel = "how to quit leagues of legends for dummies", PublishedYear = "2024", genre = "Educational" }
            );
            context.SaveChanges(); 
        }

        
        var authors = context.authors.ToList();
        var books = context.books.ToList();

        if (authors.Count == 0 || books.Count == 0)
        {
            Console.WriteLine("Authors or Books were not properly saved.");
            return;
        }

        if (!context.bookAuthors.Any())
        {
            try
            {
                context.bookAuthors.AddRange
                (
                    new BookAuthor { BookID = books.First(b => b.Titel == "Harry harmynt den 3dje").ID, AuthorID = authors.First(a => a.Name == "Devran bulduk").ID },
                    new BookAuthor { BookID = books.First(b => b.Titel == "tom the trigger").ID, AuthorID = authors.First(a => a.Name == "Pontan kalle").ID },
                    new BookAuthor { BookID = books.First(b => b.Titel == "The styler").ID, AuthorID = authors.First(a => a.Name == "Donald trump").ID },
                    new BookAuthor { BookID = books.First(b => b.Titel == "how to quit leagues of legends for dummies").ID, AuthorID = authors.First(a => a.Name == "Joe biden").ID }
                );
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel {ex.Message}");
            }
        }
    }



}