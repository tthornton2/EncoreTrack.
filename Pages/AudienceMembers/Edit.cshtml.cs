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

namespace EncoreTrack.Pages_AudienceMembers
{
    public class EditModel : PageModel
    {
        private readonly EncoreTrack.Data.AppDbContext _context;

        public EditModel(EncoreTrack.Data.AppDbContext context)
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

            var audiencemember =  await _context.AudienceMembers.FirstOrDefaultAsync(m => m.AudienceMemberID == id);
            if (audiencemember == null)
            {
                return NotFound();
            }
            AudienceMember = audiencemember;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AudienceMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AudienceMemberExists(AudienceMember.AudienceMemberID))
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

        private bool AudienceMemberExists(int id)
        {
            return _context.AudienceMembers.Any(e => e.AudienceMemberID == id);
        }
    }
}
