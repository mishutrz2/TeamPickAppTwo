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
    public class IndexModel : PageModel
    {
        private readonly TeamPickAppTwo.Data.ApplicationDbContext _context;

        public IndexModel(TeamPickAppTwo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<List> List { get;set; } = default!;

        public async Task OnGetAsync()
        {
            List = await _context.Lists.ToListAsync();
        }
    }
}
