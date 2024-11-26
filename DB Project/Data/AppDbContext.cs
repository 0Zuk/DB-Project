using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DbProject.Models;


public class AppDbContext : DbContext
{
    public DbSet<Book> books {get; set;}
    public DbSet<Author> authors {get; set;}
    public DbSet<Loan> loans {get; set;}
    public DbSet<BookAuthor> bookAuthors {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DbProject;Trusted_Connection=True;TrustServerCertificate=True;");
    }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
        .HasKey(ba => new { ba.BookID, ba.AuthorID });

        modelBuilder.Entity<BookAuthor>()
            .HasOne(Ba => Ba.Book)
            .WithMany(B => B.bookAuthors)
            .HasForeignKey(Ba => Ba.BookID);
            


             modelBuilder.Entity<BookAuthor>()
            .HasOne(Ba => Ba.Author)
            .WithMany(B => B.bookAuthors)
            .HasForeignKey(Ba => Ba.AuthorID);


             modelBuilder.Entity<Loan>()
            .HasOne(L => L.Book)
            .WithMany(bs => bs.Loans)
            .HasForeignKey(Ba => Ba.BookID);
    }

}
