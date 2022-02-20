using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateElections.Models
{
    [Table("votos_candidatos")]
    public class CandidateVote
    {
        public CandidateVote()
        {
        }
        public long Id { get; set; }
        public Campaign Cdcampana { get; set; }
        public Candidate Cdcandidato { get; set; }
        public Person CddocumentoVotante { get; set; }

    }
}
