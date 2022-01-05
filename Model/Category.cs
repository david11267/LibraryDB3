using System;
using System.Collections.Generic;

namespace LibraryDB3.Model
{
    public partial class Category
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public string? ValueName { get; set; }
        public string? Value { get; set; }

        public virtual Book? Book { get; set; }
    }
}
