
namespace DbProject.Models
{


    public class BookAuthor
    {
        public int ID { get; set; }
        public int BookID {get; set;}
        public int AuthorID { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }

    }
}