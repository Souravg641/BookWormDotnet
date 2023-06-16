using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWorm.Models;

namespace BookWorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreMastersController : ControllerBase
    {
        private readonly Ccontext _context;

        public GenreMastersController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/GenreMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreMaster>>> GetGenreMasters()
        {
          if (_context.GenreMasters == null)
          {
              return NotFound();
          }
            return await _context.GenreMasters.ToListAsync();
        }

        // GET: api/GenreMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreMaster>> GetGenreMaster(int id)
        {
          if (_context.GenreMasters == null)
          {
              return NotFound();
          }
            var genreMaster = await _context.GenreMasters.FindAsync(id);

            if (genreMaster == null)
            {
                return NotFound();
            }

            return genreMaster;
        }

        // PUT: api/GenreMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenreMaster(int id, GenreMaster genreMaster)
        {
            if (id != genreMaster.GenreId)
            {
                return BadRequest();
            }

            _context.Entry(genreMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreMasterExists(id))
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

        // POST: api/GenreMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenreMaster>> PostGenreMaster(GenreMaster genreMaster)
        {
          if (_context.GenreMasters == null)
          {
              return Problem("Entity set 'Ccontext.GenreMasters'  is null.");
          }
            _context.GenreMasters.Add(genreMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenreMaster", new { id = genreMaster.GenreId }, genreMaster);
        }

        // DELETE: api/GenreMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreMaster(int id)
        {
            if (_context.GenreMasters == null)
            {
                return NotFound();
            }
            var genreMaster = await _context.GenreMasters.FindAsync(id);
            if (genreMaster == null)
            {
                return NotFound();
            }

            _context.GenreMasters.Remove(genreMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreMasterExists(int id)
        {
            return (_context.GenreMasters?.Any(e => e.GenreId == id)).GetValueOrDefault();
        }
    }
}
