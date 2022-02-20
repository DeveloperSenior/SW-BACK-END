using System;
using CandidateElections.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateElections.Data
{
    public class CandidateElectionsContext: DbContext
    {
        public CandidateElectionsContext( DbContextOptions<CandidateElectionsContext> options )
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Elect> Elects { get; set; }
        public DbSet<CandidateVote> CandidatesVotes { get; set; }
    }
}
