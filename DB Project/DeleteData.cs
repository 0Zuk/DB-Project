using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DbProject.Models; 

public class DeleteData
{
    public static void DeleteAuthor()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("Enter author ID to delete:");
            int authorId = int.Parse(Console.ReadLine());

            var author = context.authors.Find(authorId);
            if (author != null)
            {
                context.authors.Remove(author); 
                context.SaveChanges();
                Console.WriteLine($"Author '{author.Name}' has been deleted.");
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }
    }

    public static void DeleteBook()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("Enter book ID to delete:");
            int bookId = int.Parse(Console.ReadLine());

            var book = context.books.Find(bookId);
            if (book != null)
            {
                context.books.Remove(book); 
                context.SaveChanges();
                Console.WriteLine($"Book '{book.Titel}' has been deleted.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    public static void DeleteLoan()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("Enter loan ID to delete:");
            int loanId = int.Parse(Console.ReadLine());

            var loan = context.loans.Find(loanId);
            if (loan != null)
            {
                context.loans.Remove(loan);
                context.SaveChanges();
                Console.WriteLine($"Loan with ID '{loanId}' has been deleted.");
            }
            else
            {
                Console.WriteLine("Loan not found.");
            }
        }
    }
}