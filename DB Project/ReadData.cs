using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using DbProject.Models;
using Microsoft.Identity.Client;

public class ReadData
{
    public static void ListBooksAndAuthors()
{
    using (var context = new AppDbContext())
    {
        var books = context.books
            .Include(b => b.bookAuthors) // include relation to bookauhtor
            .ThenInclude(ba => ba.Author) // include author in bookauthor
            .ToList();

        if (books.Any())
        {
            Console.WriteLine("Books and their authors:");
            foreach (var book in books)
            {
                Console.WriteLine($"Book: {book.Titel}");
                foreach (var bookAuthor in book.bookAuthors)
                {
                    Console.WriteLine($"  Author: {bookAuthor.Author.Name}");
                }
            }
        }
        else
        {
            Console.WriteLine("No books or authors found in the database.");
        }
        
    }
    
}




    public static void ListBorrowedBooks()
{
    using (var context = new AppDbContext())
    {
        var loans = context.loans
            .Include(l => l.Book) // include relation to bookauthor
            .ToList();

        if (loans.Any())
        {
            Console.WriteLine("Borrowed books and their return dates:");
            foreach (var loan in loans)
            {
                var returnDate = loan.LoanDate.AddDays(30); 
                Console.WriteLine($"Book: {loan.Book.Titel}, Borrower: {loan.LoanerName}, Return Date: {returnDate.ToShortDateString()}");
            }
        }
        else
        {
            Console.WriteLine("No borrowed books found in the database.");
        }
    }
}
public static void ListBooksByAuthor()
{
    using (var context = new AppDbContext())
    {
        Console.WriteLine("Enter Author ID to list their books:");
        int authorId = int.Parse(Console.ReadLine());

        var author = context.authors
            .Include(a => a.bookAuthors)
            .ThenInclude(ba => ba.Book)
            .FirstOrDefault(a => a.ID == authorId);

        if (author != null)
        {
            Console.WriteLine($"Books written by {author.Name}:");
            foreach (var bookAuthor in author.bookAuthors)
            {
                Console.WriteLine($"- {bookauthor.Book.titel}");
            }
        }
        else
        {
            Console.WriteLine("Author not found.");
        }
    }
}
public static void ListAuthorsByBook()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("Enter Book ID to list its authors:");
            int bookId = int.Parse(Console.ReadLine());

            var book = context.books
                .Include(b => b.bookAuthors)
                .ThenInclude(ba => ba.Author)
                .FirstOrDefault(b => b.ID == bookId);

            if (book != null)
            {
                Console.WriteLine($"Authors who contributed to {book.titel}:");
                foreach (var bookAuthor in book.bookAuthors)
                {
                    Console.WriteLine($"- {bookAuthor.Author.Name}");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
    public static void ShowLoanHistory()
    {
        using (var context = new AppDbContext())
        {
            var loans = context.loans
                .Include(l => l.Book)
                .ToList();

            if (loans.Any())
            {
                Console.WriteLine("Loan History:");
                foreach (var loan in loans)
                {
                    var returnDate = loan.LoanDate.AddDays(30); // Anta 30 dagar som lånetid
                    Console.WriteLine($"Book: {loan.Book.titel}, Borrower: {loan.loanerName}, Loan Date: {loan.LoanDate.ToShortDateString()}, Return Date: {returnDate.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No loans found in the database.");
            }
        }
    }

}