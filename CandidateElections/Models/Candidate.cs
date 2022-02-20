using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateElections.Models
{
    [Table("candidatos")]
    public class Candidate
    {
        public Candidate()
        {
        }

        public long Id { get; set; }
        public string Cdcandidato { get; set; }
        public Person Cddcumento { get; set; }
        public double Ptpresupuesto { get; set; }
        public string DspathFoto { get; set; }
    }
}
