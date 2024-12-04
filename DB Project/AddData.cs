using DbProject.Models;

    public class AddData
    {
        //method for adding an author
        public static void AddAuthor()
        {
            System.Console.WriteLine("Ge författren ett namn");
            string AuthorName = Console.ReadLine();
           
           
            using (var context = new AppDbContext())
            {
                var author = new Author { Name = AuthorName };
                context.authors.Add(author);
                context.SaveChanges();
            }
            System.Console.WriteLine("Författren är nu tillagd");
        }
                public static void AddBook()
        {
            System.Console.WriteLine("Ge boken ett namn");
            string BookName = Console.ReadLine();
            string Genre = Console.ReadLine();
            string Pubyear = Console.ReadLine();
           
           
            using (var context = new AppDbContext())
            {
                var Book = new Book { Titel = BookName, genre = Genre, PublishedYear = Pubyear };

                context.books.Add(Book);
                context.SaveChanges();
            }
            System.Console.WriteLine("Boken är nu tillagd");
        }
        //meyhod for adding relation to author and a book
public static void AddBookAuthorRelation()
    {
        using (var context = new AppDbContext())
        {

            
            System.Console.WriteLine("Enter the book ID to associate it with an author of your choice: ");
                foreach (var item in context.books.ToList())
                {
                   System.Console.WriteLine($"Välj mellan dessa ID {item.Titel} {item.ID}"); 
                }
            int bookID = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter author ID to associate it with the book");
            int authorID = int.Parse(Console.ReadLine());

            var book = context.books.Find(bookID); //Finds the book
            var author = context.authors.Find(authorID); //Finds the author

            if (book != null && author != null)
            {
                var bookAuthor = new BookAuthor
                {
                    BookID = bookID,
                    AuthorID = authorID
                };

                context.bookAuthors.Add(bookAuthor); //Adds the relation between book and author into the database
                context.SaveChanges();

                System.Console.WriteLine($"Great! The book '{book.Titel}' has been associated with Author '{author.Name}'.");
            }
            else
            {
                System.Console.WriteLine("Either the book or author was not found");
            }

        }

    }

    // method for adding loan
    public static void AddLoan()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("Enter book ID to loan the book");
            int bookID = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter borrower name: ");
            string borrower = Console.ReadLine();

            var book = context.books.Find(bookID);

            if (book != null)
            {
                var loan = new Loan
                {
                    BookID = bookID,
                    LoanerName = borrower,
                    LoanDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(30)
                };

                context.loans.Add(loan);
                context.SaveChanges();

                System.Console.WriteLine($"Loan added for book '{book.Titel}' to borrower '{borrower}!");
            }
            else
            {
                System.Console.WriteLine("Book not found!");
            }
        }
    }
}

    
    
