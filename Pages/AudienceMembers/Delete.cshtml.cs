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
    public class DeleteModel : PageModel
    {
        private readonly EncoreTrack.Data.AppDbContext _context;

        public DeleteModel(EncoreTrack.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AudienceMember AudienceMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audiencemember = await _context.AudienceMembers.FirstOrDefaultAsync(m => m.AudienceMemberID == id);

            if (audiencemember is not null)
            {
                AudienceMember = audiencemember;

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

            var audiencemember = await _context.AudienceMembers.FindAsync(id);
            if (audiencemember != null)
            {
                AudienceMember = audiencemember;
                _context.AudienceMembers.Remove(AudienceMember);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
