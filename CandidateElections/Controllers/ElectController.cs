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
    public class ElectController : ControllerBase
    {
        private readonly CandidateElectionsContext _context;

        public ElectController(CandidateElectionsContext context)
        {
            _context = context;
        }

        // GET: api/Elect
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elect>>> GetElects()
        {
            return await _context.Elects.ToListAsync();
        }

        // GET: api/Elect/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elect>> GetElect(long id)
        {
            var elect = await _context.Elects.FindAsync(id);

            if (elect == null)
            {
                return NotFound();
            }

            return elect;
        }

        // PUT: api/Elect/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElect(long id, Elect elect)
        {
            if (id != elect.Id)
            {
                return BadRequest();
            }

            _context.Entry(elect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectExists(id))
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

        // POST: api/Elect
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Elect>> PostElect(Elect elect)
        {
            _context.Elects.Add(elect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElect", new { id = elect.Id }, elect);
        }

        // DELETE: api/Elect/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElect(long id)
        {
            var elect = await _context.Elects.FindAsync(id);
            if (elect == null)
            {
                return NotFound();
            }

            _context.Elects.Remove(elect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElectExists(long id)
        {
            return _context.Elects.Any(e => e.Id == id);
        }
    }
}
