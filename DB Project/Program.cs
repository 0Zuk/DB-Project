using DbProject.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using Microsoft.EntityFrameworkCore;





class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
    
       {     context.Database.Migrate();

            
            SeedData.Initialize(context);
       }





    bool meny = false; //menu choice for user
            while (!meny)
            {
                Console.WriteLine("\nVälj ett menyval");
                Console.WriteLine("[1] Lägg till författare");
                Console.WriteLine("[2] Lägg till en bok");
                Console.WriteLine("[3] Skapa relation mellan författare och bok");
                Console.WriteLine("[4] Lägg till ett lån");
                Console.WriteLine("[5] skriv ut böcker och författare");
                Console.WriteLine("[6] skriv ut lånade böcker och deras återdatum");
                Console.WriteLine("[7] tabort författre");
                Console.WriteLine("[8] tabort bok");
                Console.WriteLine("[9] tabort lån");
                Console.WriteLine("[10] skriv ut böcker med samma författre");
                Console.WriteLine("[11]skriv ut författre med samma bok");
                Console.WriteLine("[12] Lånehistorik");
                Console.WriteLine("[13] avsluta");


                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddData.AddAuthor();
                        break;
                    case "2":
                        AddData.AddBook();
                        break;
                    case "3":
                    
                        AddData.AddBookAuthorRelation();
                        break;
                    case "4":
                        AddData.AddLoan();
                        break;
                    case "5":
                        ReadData.ListBooksAndAuthors();
                        break;
                    case "6":
                        ReadData.ListBorrowedBooks();
                        break;
                    case "7":
                        DeleteData.DeleteAuthor();
                        break;
                    case "8":
                        DeleteData.DeleteBook();
                        break;
                    case "9":
                        DeleteData.DeleteLoan();
                        break;
                    case "10":
                        ReadData.ListBooksByAuthor();
                        break;
                    case "11":
                        ReadData.ListAuthorsByBook();
                        break;
                    case "12":
                        ReadData.ShowLoanHistory();
                        break;
                    case "13":
                        meny = true;
                        break;
                    default: //simple error handling
                        Console.WriteLine("Fel, försök igen");
                        break;
            }

        }
        
       }
       
    }


