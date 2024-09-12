using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamPickAppTwo.Data;
using TeamPickAppTwo.Data.ViewSql;

namespace TeamPickAppTwo.Pages.ListManagement
{
    public class EditModel : PageModel
    {
        private readonly TeamPickAppTwo.Data.ApplicationDbContext _context;

        public EditModel(TeamPickAppTwo.Data.ApplicationDbContext context)
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

            var list =  await _context.Lists.FirstOrDefaultAsync(m => m.ListId == id);
            if (list == null)
            {
                return NotFound();
            }
            List = list;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(List).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListExists(List.ListId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ListExists(Guid id)
        {
            return _context.Lists.Any(e => e.ListId == id);
        }
    }
}
