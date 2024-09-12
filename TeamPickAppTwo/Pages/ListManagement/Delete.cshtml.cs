using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamPickAppTwo.Data;
using TeamPickAppTwo.Data.ViewSql;

namespace TeamPickAppTwo.Pages.ListManagement
{
    public class DeleteModel : PageModel
    {
        private readonly TeamPickAppTwo.Data.ApplicationDbContext _context;

        public DeleteModel(TeamPickAppTwo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List List { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = await _context.Lists.FirstOrDefaultAsync(m => m.ListId == id);

            if (list == null)
            {
                return NotFound();
            }
            else
            {
                List = list;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = await _context.Lists.FindAsync(id);
            if (list != null)
            {
                List = list;
                _context.Lists.Remove(List);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
