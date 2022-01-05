using System;
using System.Collections.Generic;

namespace LibraryDB3.Model
{
    public partial class Customer
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public string? CustomerName { get; set; }

        public virtual Book? Book { get; set; }
    }
}
