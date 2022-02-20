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
    public class VoterController : ControllerBase
    {
        private readonly CandidateElectionsContext _context;

        public VoterController(CandidateElectionsContext context)
        {
            _context = context;
        }

        // GET: api/Voter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voter>>> GetVoters()
        {
            return await _context.Voters.ToListAsync();
        }

        // GET: api/Voter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voter>> GetVoter(long id)
        {
            var voter = await _context.Voters.FindAsync(id);

            if (voter == null)
            {
                return NotFound();
            }

            return voter;
        }

        // PUT: api/Voter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoter(long id, Voter voter)
        {
            if (id != voter.Id)
            {
                return BadRequest();
            }

            _context.Entry(voter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoterExists(id))
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

        // POST: api/Voter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voter>> PostVoter(Voter voter)
        {
            _context.Voters.Add(voter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoter", new { id = voter.Id }, voter);
        }

        // DELETE: api/Voter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoter(long id)
        {
            var voter = await _context.Voters.FindAsync(id);
            if (voter == null)
            {
                return NotFound();
            }

            _context.Voters.Remove(voter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoterExists(long id)
        {
            return _context.Voters.Any(e => e.Id == id);
        }
    }
}
