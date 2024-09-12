using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TeamPickAppTwo.Data;
using TeamPickAppTwo.Data.ViewSql;

namespace TeamPickAppTwo.Pages.ListManagement
{
    public class CreateModel : PageModel
    {
        private readonly TeamPickAppTwo.Data.ApplicationDbContext _context;

        public CreateModel(TeamPickAppTwo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public List List { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Check if the name already exists
                if (_context.Lists.Any(l => l.Name == List.Name))
                {
                    ModelState.AddModelError("List.Name", "The name is already in use.");
                    return Page();
                }

                _context.Lists.Add(List);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Index");
            }
            catch (DbUpdateException ex)
            {
                // Handle the unique constraint violation exception
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627) // Unique constraint error code
                {
                    ModelState.AddModelError("List.Name", "The name is already in use. Please enter a different name.");
                }
                else
                {
                    // Log and handle other exceptions
                    ModelState.AddModelError("", "An error occurred while saving the data.");
                }

                return Page();
            }

            _context.Lists.Add(List);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
