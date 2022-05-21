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
        [Column("id")]
        public long Id { get; set; }
        [Column("cdcampana")]
        public string CdCampana { get; set; }
        [Column("dscampana")]
        public string DsCampana { get; set; }
    }
}
