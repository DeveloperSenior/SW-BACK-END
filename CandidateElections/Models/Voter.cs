using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateElections.Models
{
    [Table("votantes")]
    public class Voter
    {
        public Voter()
        {
        }

        public long Id { get; set; }
        public Person Cddocumento { get; set; }
        public Campaign Cdcampana { get; set; }
        public Table CdmesaAsignada { get; set; }
        public string Snvoto { get; set; }
    }
}
