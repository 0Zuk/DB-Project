using DbProject.Models;

namespace DbProject.Models
{ 
        public class Loan
        {
            public int ID { get; set; }
            public int BookID { get; set; }
            public Book? Book { get; set; }
            public DateTime LoanDate { get; set; }
            public DateTime ReturnDate { get; set; }
            public string LoanerName { get; set; }
            public string PersonNr { get; set; }
            
        }
}