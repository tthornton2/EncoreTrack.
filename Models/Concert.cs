using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EncoreTrack.Models
{
    public class Concert
    {
        public int ConcertID { get; set; }

        [Required]
        [Display(Name = "Concert Name")]
        public string ConcertName { get; set; }

        [Required]
        [Display(Name = "Concert Date")]
        public DateTime ConcertDate { get; set; }

        [Required]
        public string Venue { get; set; }

    
        public List<ConcertVisit> ConcertVisits { get; set; } = new();
    }
}
