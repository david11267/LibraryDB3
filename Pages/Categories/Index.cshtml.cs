#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryDB3.Model;

namespace LibraryDB3.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly LibraryDB3.Model.LibraryDB3Context _context;

        public IndexModel(LibraryDB3.Model.LibraryDB3Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories
                .Include(c => c.Book).ToListAsync();
        }
    }
}
