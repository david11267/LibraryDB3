using System;
using System.Collections.Generic;

namespace LibraryDB3.Model
{
    public partial class Book
    {
        public Book()
        {
            Categories = new HashSet<Category>();
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public bool? Bought { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? BookCost { get; set; }

        public virtual Author? Author { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
