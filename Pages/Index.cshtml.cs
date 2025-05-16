using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EncoreTrack.Data;
using EncoreTrack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncoreTrack.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Concert> Concerts { get; set; }

        public async Task OnGetAsync()
        {
            Concerts = await _context.Concerts
                .OrderBy(c => c.ConcertDate)
                .ToListAsync();
        }
    }
}

