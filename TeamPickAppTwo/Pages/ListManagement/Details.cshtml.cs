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
    public class DetailsModel : PageModel
    {
        private readonly TeamPickAppTwo.Data.ApplicationDbContext _context;

        public DetailsModel(TeamPickAppTwo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
