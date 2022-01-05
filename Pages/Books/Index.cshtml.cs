#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryDB3.Model;

namespace LibraryDB3.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly LibraryDB3.Model.LibraryDB3Context _context;

        public IndexModel(LibraryDB3.Model.LibraryDB3Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        public IList<Author> Author { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Author).ToListAsync();
        }
    }
}
