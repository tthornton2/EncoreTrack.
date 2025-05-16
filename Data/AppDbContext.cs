using Microsoft.EntityFrameworkCore;
using EncoreTrack.Models;

namespace EncoreTrack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<AudienceMember> AudienceMembers { get; set; }
        public DbSet<ConcertVisit> ConcertVisits { get; set; }
        public DbSet<Concert> Concerts { get; set; }

    }
}
