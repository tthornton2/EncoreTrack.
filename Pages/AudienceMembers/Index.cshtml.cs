using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EncoreTrack.Data;
using EncoreTrack.Models;

namespace EncoreTrack.Pages.AudienceMembers
{
//db
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

//paging
                public int CurrentPage { get; set; }
                public int TotalPages { get; set; }

                [BindProperty(SupportsGet = true)]
                public int PageNumber { get; set; } = 1;

                private const int PageSize = 10;

//sort
                [BindProperty(SupportsGet = true)]
                public string SortOrder { get; set; }

//sb
        public IList<AudienceMember> AudienceMember { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.AudienceMembers
                .Include(a => a.ConcertVisits)
                .AsQueryable();


            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(a =>
                    a.FullName.Contains(SearchString) ||
                    a.Email.Contains(SearchString));
            }
//ps
                int totalCount = await query.CountAsync();
                TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
                CurrentPage = PageNumber;

                    switch (SortOrder)
                    {
                        case "name_desc":
                            query = query.OrderByDescending(a => a.FullName);
                            break;
                        default:
                            query = query.OrderBy(a => a.FullName);
                            break;
                    }

                    AudienceMember = await query
                        .Skip((PageNumber - 1) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();

        }
    }
}
