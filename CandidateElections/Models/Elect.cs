using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateElections.Models
{
    [Table("electos")]
    public class Elect
    {
        public Elect()
        {
        }

        public long Id { get; set; }
        public Candidate Cdcandidato { get; set; }
        public Campaign Cdcampana { get; set; }
        public Person Cddocumento { get; set; }
        public DateTime FeperiodoInicio { get; set; }
        public DateTime FeperiodoFin { get; set; }
        public long Nmvotos { get; set; }
        
    }
}
