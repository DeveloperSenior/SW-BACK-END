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
    public class TableController : ControllerBase
    {
        private readonly CandidateElectionsContext _context;

        public TableController(CandidateElectionsContext context)
        {
            _context = context;
        }

        // GET: api/Table
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return await _context.Tables.ToListAsync();
        }

        // GET: api/Table/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(long id)
        {
            var table = await _context.Tables.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }

        // PUT: api/Table/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(long id, Table table)
        {
            if (id != table.Id)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
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

        // POST: api/Table
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTable", new { id = table.Id }, table);
        }

        // DELETE: api/Table/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(long id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableExists(long id)
        {
            return _context.Tables.Any(e => e.Id == id);
        }
    }
}
