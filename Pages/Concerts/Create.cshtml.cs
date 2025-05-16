using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EncoreTrack.Data;
using EncoreTrack.Models;

namespace EncoreTrack.Pages_Concerts
{
    public class CreateModel : PageModel
    {
//dbs
        private readonly EncoreTrack.Data.AppDbContext _context;

        public CreateModel(EncoreTrack.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Concert Concert { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Concerts.Add(Concert);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
