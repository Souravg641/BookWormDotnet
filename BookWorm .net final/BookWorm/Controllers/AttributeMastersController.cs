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
    public class AttributeMastersController : ControllerBase
    {
        private readonly Ccontext _context;

        public AttributeMastersController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/AttributeMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeMaster>>> GetAttributesMasters()
        {
          if (_context.AttributesMasters == null)
          {
              return NotFound();
          }
            return await _context.AttributesMasters.ToListAsync();
        }

        // GET: api/AttributeMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeMaster>> GetAttributeMaster(int id)
        {
          if (_context.AttributesMasters == null)
          {
              return NotFound();
          }
            var attributeMaster = await _context.AttributesMasters.FindAsync(id);

            if (attributeMaster == null)
            {
                return NotFound();
            }

            return attributeMaster;
        }

        // PUT: api/AttributeMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttributeMaster(int id, AttributeMaster attributeMaster)
        {
            if (id != attributeMaster.AttributeId)
            {
                return BadRequest();
            }

            _context.Entry(attributeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeMasterExists(id))
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

        // POST: api/AttributeMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AttributeMaster>> PostAttributeMaster(AttributeMaster attributeMaster)
        {
          if (_context.AttributesMasters == null)
          {
              return Problem("Entity set 'Ccontext.AttributesMasters'  is null.");
          }
            _context.AttributesMasters.Add(attributeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttributeMaster", new { id = attributeMaster.AttributeId }, attributeMaster);
        }

        // DELETE: api/AttributeMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttributeMaster(int id)
        {
            if (_context.AttributesMasters == null)
            {
                return NotFound();
            }
            var attributeMaster = await _context.AttributesMasters.FindAsync(id);
            if (attributeMaster == null)
            {
                return NotFound();
            }

            _context.AttributesMasters.Remove(attributeMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttributeMasterExists(int id)
        {
            return (_context.AttributesMasters?.Any(e => e.AttributeId == id)).GetValueOrDefault();
        }
    }
}
