using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EncoreTrack.Data;
using EncoreTrack.Models;

namespace EncoreTrack.Pages_AudienceMembers
{
    public class DetailsModel : PageModel
    {
        private readonly EncoreTrack.Data.AppDbContext _context;

        public DetailsModel(EncoreTrack.Data.AppDbContext context)
        {
            _context = context;
        }

//amaddition
        public AudienceMember AudienceMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
    if (id == null)
    {
        return NotFound();
    }

    AudienceMember = await _context.AudienceMembers
    .Include(a => a.ConcertVisits)
        .ThenInclude(cv => cv.Concert) // 👈 Add this
    .FirstOrDefaultAsync(m => m.AudienceMemberID == id);


    if (AudienceMember == null)
    {
        return NotFound();
    }

    return Page();
            }
            public async Task<IActionResult> OnPostDeleteVisitAsync(int id, int visitId)
    {
        var visit = await _context.ConcertVisits.FindAsync(visitId);
        if (visit != null)
        {
            _context.ConcertVisits.Remove(visit);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage(new { id });
    }
        }
        }
    