using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EncoreTrack.Models
{
    public class AudienceMember
    {
        public int AudienceMemberID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "First Visit Date")]
        public DateTime FirstVisitDate { get; set; }

        public string Notes { get; set; }

        public List<ConcertVisit> ConcertVisits { get; set; } = new();
    }
}
