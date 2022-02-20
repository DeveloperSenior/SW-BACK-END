using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CandidateElections.Data;
using CandidateElections.Models;

namespace CandidateElections.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateVoteController : ControllerBase
    {
        private readonly CandidateElectionsContext _context;

        public CandidateVoteController(CandidateElectionsContext context)
        {
            _context = context;
        }

        // GET: api/CandidateVote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateVote>>> GetCandidatesVotes()
        {
            return await _context.CandidatesVotes.ToListAsync();
        }

        // GET: api/CandidateVote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateVote>> GetCandidateVote(long id)
        {
            var candidateVote = await _context.CandidatesVotes.FindAsync(id);

            if (candidateVote == null)
            {
                return NotFound();
            }

            return candidateVote;
        }

        // PUT: api/CandidateVote/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateVote(long id, CandidateVote candidateVote)
        {
            if (id != candidateVote.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidateVote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateVoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CandidateVote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CandidateVote>> PostCandidateVote(CandidateVote candidateVote)
        {
            _context.CandidatesVotes.Add(candidateVote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidateVote", new { id = candidateVote.Id }, candidateVote);
        }

        // DELETE: api/CandidateVote/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidateVote(long id)
        {
            var candidateVote = await _context.CandidatesVotes.FindAsync(id);
            if (candidateVote == null)
            {
                return NotFound();
            }

            _context.CandidatesVotes.Remove(candidateVote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidateVoteExists(long id)
        {
            return _context.CandidatesVotes.Any(e => e.Id == id);
        }
    }
}
