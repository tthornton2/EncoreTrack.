using System;
using System.Linq;
using EncoreTrack.Models;

namespace EncoreTrack.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

//bascon
            if (!context.Concerts.Any())
            {
                var concerts = new Concert[]
                {
                    new() { ConcertName = "Pictures at an Exhibition", ConcertDate = new DateTime(2024, 9, 13), Venue = "Symphony" },
                    new() { ConcertName = "The Visual Meets the Aural", ConcertDate = new DateTime(2024, 9, 27), Venue = "CMA" },
                    new() { ConcertName = "100th Anniversary Concert", ConcertDate = new DateTime(2024, 10, 11), Venue = "Symphony" },
                    new() { ConcertName = "Happy Holiday Pops", ConcertDate = new DateTime(2024, 12, 20), Venue = "Symphony" },
                    new() { ConcertName = "The Firebird", ConcertDate = new DateTime(2025, 4, 25), Venue = "Symphony" }
                };
                context.Concerts.AddRange(concerts);
                context.SaveChanges();
            }

//baspat
            if (!context.AudienceMembers.Any())
            {
                var members = new AudienceMember[]
                
//generated names with some of my edits
                {
                    new() { FullName = "Aria Bell", Email = "aria.bell@example.com", PhoneNumber = "555-1234", FirstVisitDate = new DateTime(2024, 9, 13), Notes = "Likes Mahler" },
                    new() { FullName = "Melody Carter", Email = "melody.carter@example.com", PhoneNumber = "555-5678", FirstVisitDate = new DateTime(2024, 10, 11), Notes = "First time patron" },
                    new() { FullName = "Caden Sharp", Email = "caden.sharp@example.com", PhoneNumber = "555-0000", FirstVisitDate = new DateTime(2024, 12, 20), Notes = "" },
                    new() { FullName = "Lyric Scale", Email = "lyric.scale@symphony.org", PhoneNumber = "555-4801", FirstVisitDate = DateTime.Parse("2024-04-09"), Notes = "Pianist"},
                    new() { FullName = "Octave Forte", Email = "octave.forte@symphony.org", PhoneNumber = "555-4745", FirstVisitDate = DateTime.Parse("2024-02-28"), Notes = "Mom recently passed" },
                    new() { FullName = "Solo Ledger", Email = "solo.ledger@symphony.org", PhoneNumber = "555-6283", FirstVisitDate = DateTime.Parse("2024-03-13"), Notes = "Enthusiastic patron" },
                    new() { FullName = "Chord Scale", Email = "chord.scale@symphony.org", PhoneNumber = "555-2188", FirstVisitDate = DateTime.Parse("2024-04-24"), Notes = "Dislikes Bach" },
                    new() { FullName = "Lyric Tone", Email = "lyric.tone@symphony.org", PhoneNumber = "555-5637", FirstVisitDate = DateTime.Parse("2024-04-26"), Notes = "Enthusiastic patron" },
                    new() { FullName = "Harmony Scale", Email = "harmony.scale@symphony.org", PhoneNumber = "555-5380", FirstVisitDate = DateTime.Parse("2024-04-24"), Notes = "Bad experience last time" },
                    new() { FullName = "Cadence Tone", Email = "cadence.tone@symphony.org", PhoneNumber = "555-9260", FirstVisitDate = DateTime.Parse("2024-03-31"), Notes = "Likes aisle seats" },
                    new() { FullName = "Lyric Sharp", Email = "lyric.sharp@symphony.org", PhoneNumber = "555-4812", FirstVisitDate = DateTime.Parse("2024-02-18"), Notes = "Needs accessible seating" },
                    new() { FullName = "Timbre Note", Email = "timbre.note@symphony.org", PhoneNumber = "555-7647", FirstVisitDate = DateTime.Parse("2024-04-28"), Notes = "Possible Donor" },
                    new() { FullName = "Octave Note", Email = "octave.note@symphony.org", PhoneNumber = "555-6837", FirstVisitDate = DateTime.Parse("2024-03-29"), Notes = "Enthusiastic patron" },
                    new() { FullName = "Lyric Scale", Email = "lyric.scale@symphony.org", PhoneNumber = "555-4577", FirstVisitDate = DateTime.Parse("2024-05-29"), Notes = "Sister of percussionist" },
                    new() { FullName = "Reed Clef", Email = "reed.clef@symphony.org", PhoneNumber = "555-6338", FirstVisitDate = DateTime.Parse("2024-05-17"), Notes = "Kid in Youth Orchestra" },
                    new() { FullName = "Chord Clef", Email = "chord.clef@symphony.org", PhoneNumber = "555-5320", FirstVisitDate = DateTime.Parse("2024-02-12"), Notes = "Possible Donor" },
                    new() { FullName = "Allegro Bell", Email = "allegro.bell@symphony.org", PhoneNumber = "555-9729", FirstVisitDate = DateTime.Parse("2024-05-11"), Notes = "Enthusiastic patron" },
                    new() { FullName = "Aria Bell", Email = "aria.bell@symphony.org", PhoneNumber = "555-5080", FirstVisitDate = DateTime.Parse("2024-03-22"), Notes = "Enthusiastic patron" },
                    new() { FullName = "Aria Bell", Email = "aria.bell@symphony.org", PhoneNumber = "555-8500", FirstVisitDate = DateTime.Parse("2024-05-23"), Notes = "Wants to audition" },
                    new() { FullName = "Harmony Chord", Email = "harmony.chord@symphony.org", PhoneNumber = "555-4096", FirstVisitDate = DateTime.Parse("2024-04-11"), Notes = "Comes with family" },
                    new() { FullName = "Reed Note", Email = "reed.note@symphony.org", PhoneNumber = "555-1471", FirstVisitDate = DateTime.Parse("2024-04-06"), Notes = "No notes so far" },
                    new() { FullName = "Timbre Clef", Email = "timbre.clef@symphony.org", PhoneNumber = "555-4325", FirstVisitDate = DateTime.Parse("2024-05-23"), Notes = "Possible Donor" },
                    new() { FullName = "Allegro Scale", Email = "allegro.scale@symphony.org", PhoneNumber = "555-1197", FirstVisitDate = DateTime.Parse("2024-03-14"), Notes = "Enthusiastic patron" },
                    new() { FullName = "Allegro Bass", Email = "allegro.bass@symphony.org", PhoneNumber = "555-8741", FirstVisitDate = DateTime.Parse("2024-04-22"), Notes = "Violinist" },
                };
                context.AudienceMembers.AddRange(members);
                context.SaveChanges();
            }


            if (!context.ConcertVisits.Any())
            {
//generated visits
                var visits = new ConcertVisit[]
            {
                new ConcertVisit { AudienceMemberID = 5, ConcertID = 2 },
                new ConcertVisit { AudienceMemberID = 6, ConcertID = 2 },
                new ConcertVisit { AudienceMemberID = 6, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 7, ConcertID = 5 },
                new ConcertVisit { AudienceMemberID = 7, ConcertID = 2 },
                new ConcertVisit { AudienceMemberID = 7, ConcertID = 1 },
                new ConcertVisit { AudienceMemberID = 8, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 9, ConcertID = 5 },
                new ConcertVisit { AudienceMemberID = 9, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 10, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 11, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 11, ConcertID = 1 },
                new ConcertVisit { AudienceMemberID = 11, ConcertID = 2 },
                new ConcertVisit { AudienceMemberID = 12, ConcertID = 1 },
                new ConcertVisit { AudienceMemberID = 12, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 12, ConcertID = 5 },
                new ConcertVisit { AudienceMemberID = 13, ConcertID = 5 },
                new ConcertVisit { AudienceMemberID = 14, ConcertID = 5 },
                new ConcertVisit { AudienceMemberID = 15, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 16, ConcertID = 5 },
                new ConcertVisit { AudienceMemberID = 17, ConcertID = 2 },
                new ConcertVisit { AudienceMemberID = 18, ConcertID = 2 },
                new ConcertVisit { AudienceMemberID = 18, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 19, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 20, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 20, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 21, ConcertID = 2 },
                new ConcertVisit { AudienceMemberID = 21, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 22, ConcertID = 2 },
                new ConcertVisit { AudienceMemberID = 22, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 23, ConcertID = 1 },
                new ConcertVisit { AudienceMemberID = 23, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 23, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 24, ConcertID = 2 },
                new ConcertVisit { AudienceMemberID = 24, ConcertID = 5 },
                new ConcertVisit { AudienceMemberID = 24, ConcertID = 1 },
                new ConcertVisit { AudienceMemberID = 25, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 26, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 26, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 27, ConcertID = 3 },
                new ConcertVisit { AudienceMemberID = 27, ConcertID = 1 },
                new ConcertVisit { AudienceMemberID = 28, ConcertID = 4 },
                new ConcertVisit { AudienceMemberID = 28, ConcertID = 2 },
            };
                context.SaveChanges();
            }
        }
    }
}
