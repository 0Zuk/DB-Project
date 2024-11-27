using DbProject.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using System;



class Program
{
    static void Main(string[] args)
    {

       bool meny = false;
       while(!meny) 
       {
       System.Console.WriteLine("[1] Lägg till en författare");
       System.Console.WriteLine("[2] Lägg till en bok");
       System.Console.WriteLine("[3] Koppla en bok med en författare");
       System.Console.WriteLine("[4] Låna en bok");
       System.Console.WriteLine("[5] Tabort författre,bok och lån");
       System.Console.WriteLine("[6] Avsluta");
       
       var input = Console.ReadLine();
        
        switch (input)
        {
            case "1":
            
                break;
            
            
            case "2":
            

                break;
            
            case "3":
            
                break;
            
            case "4":
            
                break;
            
            case "5":
            
                break;
            
            case "6":
            
                System.Console.WriteLine("Välkommen åter!");
               meny = true;
               
               break;

            default:
            System.Console.WriteLine("Fel input försök med ett annat");
            break;

        }
        
       }
       
    }
}
