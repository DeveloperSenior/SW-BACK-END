using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateElections.Models
{
    [Table("mesas")]
    public class Table
    {
        public Table()
        {
        }
        public long Id { get; set; }
        public string Cdmesa { get; set; }
        public string Cdciudad { get; set; }
    }
}
