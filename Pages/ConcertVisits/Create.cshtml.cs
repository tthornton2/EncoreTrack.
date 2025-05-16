using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EncoreTrack.Data;
using EncoreTrack.Models;

namespace EncoreTrack.Pages.ConcertVisits
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ConcertVisit ConcertVisit { get; set; }

        public AudienceMember AudienceMember { get; set; }
        public SelectList ConcertList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? audienceMemberId)
        {
            if (audienceMemberId == null)
            {
                return RedirectToPage("/AudienceMembers/Index");
            }

            AudienceMember = await _context.AudienceMembers.FindAsync(audienceMemberId);
            if (AudienceMember == null)
            {
                return NotFound();
            }

            ConcertVisit = new ConcertVisit
            {
                AudienceMemberID = audienceMemberId.Value
            };

            ConcertList = new SelectList(await _context.Concerts.OrderBy(c => c.ConcertDate).ToListAsync(), "ConcertID", "ConcertName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ConcertList = new SelectList(await _context.Concerts.ToListAsync(), "ConcertID", "ConcertName");
                return Page();
            }

            _context.ConcertVisits.Add(ConcertVisit);
            await _context.SaveChangesAsync();

            return RedirectToPage("/AudienceMembers/Details", new { id = ConcertVisit.AudienceMemberID });
        }
    }
}
