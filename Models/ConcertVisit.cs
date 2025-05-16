using System;
using System.ComponentModel.DataAnnotations;

namespace EncoreTrack.Models
{
    public class ConcertVisit
    {
        public int ConcertVisitID { get; set; }

        [Required]
        [Display(Name = "Concert")]
        public int ConcertID { get; set; }
        public Concert Concert { get; set; }


        [Required]
        public int AudienceMemberID { get; set; }
        public AudienceMember AudienceMember { get; set; }
    }
}

