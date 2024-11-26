
namespace DbProject.Models
{ 
    public class Book 
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public string genre { get; set; }
        public string PublishedYear { get; set; }
        public ICollection<BookAuthor> bookAuthors {get; set;}
        public ICollection<Loan> Loans {get; set;}
    }
}