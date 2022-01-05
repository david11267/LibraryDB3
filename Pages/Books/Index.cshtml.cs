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
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }
        public IList<String> Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(string genre)
        {
            if (searchString == null)
            {
                if (genre == null)
                {
                    Book = await _context.Books.Include(b => b.Author).ToListAsync();
                    Genre = Book.Select(b => b.Genre).Distinct().ToList();
                    return Page();

                }

                Book = await _context.Books
                    .Include(b => b.Author).Where(s => s.Genre.Contains(genre)).ToListAsync();
                Genre = Book.Select(b => b.Genre).Distinct().ToList();

                if (Book == null)
                {
                    return NotFound();
                }
            }

            else
            {
                if (genre == null)
                {
                    Book = await _context.Books
                   .Include(b => b.Author).Where(s => s.Author.AuthorName.Contains(searchString)).ToListAsync();
                    Genre = Book.Select(b => b.Genre).Distinct().ToList();
                    return Page();

                }

                Book = await _context.Books
                    .Include(b => b.Author).Where(s => s.Author.AuthorName.Contains(searchString)).ToListAsync();
                Genre = Book.Select(b => b.Genre).Distinct().ToList();

                if (Book == null)
                {
                    return NotFound();
                }
            }
            
            

            return Page();
        }
      
    }
}

