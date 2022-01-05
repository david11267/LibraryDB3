#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryDB3.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryDB3.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly LibraryDB3.Model.LibraryDB3Context _context;

        public CreateModel(LibraryDB3.Model.LibraryDB3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }
        [BindProperty]
        public Author Authors { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

       
    }
}
