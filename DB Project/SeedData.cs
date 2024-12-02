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
                new Author { Name = "J.K. Rowling" },
                new Author { Name = "George R.R. Martin" },
                new Author { Name = "J.R.R. Tolkien" },
                new Author { Name = "E. Aladdin" }
                
            );
        }

        if (!context.books.Any())
        {
            
            context.books.AddRange(
                new Book { Titel = "Harry Potter and the Sorcerer's Stone", PublishedYear = "1997", genre = "Fantasy" },
                new Book { Titel = "Game of Thrones", PublishedYear = "1996", genre = "Fantasy" },
                new Book { Titel = "The Hobbit", PublishedYear = "1937", genre = "Fantasy" },
                new Book { Titel = "Aladdin and the pupils", PublishedYear = "2024", genre = "Educational"}
            );
        }

        if (!context.bookAuthors.Any())
        {
           
            context.bookAuthors.AddRange(
                new BookAuthor { BookID = 1, AuthorID = 1 },
                new BookAuthor { BookID = 2, AuthorID = 2 },
                new BookAuthor { BookID = 3, AuthorID = 3 },
                new BookAuthor { BookID = 4, AuthorID = 4 }
            );
        }


        context.SaveChanges();
    }
}