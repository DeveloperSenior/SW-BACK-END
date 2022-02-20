using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateElections.Models
{
    [Table("campanas")]
    public class Campaign
    {
        public Campaign()
        {
        }

        public long Id { get; set; }
        public string Cdcampana { get; set; }
        public string Dscampana { get; set; }
    }
}
