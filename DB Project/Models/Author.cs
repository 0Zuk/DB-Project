using System;


namespace DbProject.Models
{ 
        public class Author
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string DateOfBirth { get; set; }
            public ICollection<BookAuthor> bookAuthors {get; set;} = new List<BookAuthor> ();
        }
}
