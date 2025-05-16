using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EncoreTrack.Data;
using EncoreTrack.Models;

namespace EncoreTrack.Pages_Concerts
{
    public class DeleteModel : PageModel
    {
        private readonly EncoreTrack.Data.AppDbContext _context;

        public DeleteModel(EncoreTrack.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Concert Concert { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concerts.FirstOrDefaultAsync(m => m.ConcertID == id);

            if (concert is not null)
            {
                Concert = concert;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concerts.FindAsync(id);
            if (concert != null)
            {
                Concert = concert;
                _context.Concerts.Remove(Concert);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
