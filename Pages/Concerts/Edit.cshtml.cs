using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EncoreTrack.Data;
using EncoreTrack.Models;

namespace EncoreTrack.Pages_Concerts
{
    public class EditModel : PageModel
    {
        private readonly EncoreTrack.Data.AppDbContext _context;

        public EditModel(EncoreTrack.Data.AppDbContext context)
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

            var concert =  await _context.Concerts.FirstOrDefaultAsync(m => m.ConcertID == id);
            if (concert == null)
            {
                return NotFound();
            }
            Concert = concert;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Concert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcertExists(Concert.ConcertID))
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

        private bool ConcertExists(int id)
        {
            return _context.Concerts.Any(e => e.ConcertID == id);
        }
    }
}
