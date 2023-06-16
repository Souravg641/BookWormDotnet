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
    public class LanguageMastersController : ControllerBase
    {
        private readonly Ccontext _context;

        public LanguageMastersController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/LanguageMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageMaster>>> GetLanguageMasters()
        {
          if (_context.LanguageMasters == null)
          {
              return NotFound();
          }
            return await _context.LanguageMasters.ToListAsync();
        }

        // GET: api/LanguageMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageMaster>> GetLanguageMaster(int id)
        {
          if (_context.LanguageMasters == null)
          {
              return NotFound();
          }
            var languageMaster = await _context.LanguageMasters.FindAsync(id);

            if (languageMaster == null)
            {
                return NotFound();
            }

            return languageMaster;
        }

        // PUT: api/LanguageMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguageMaster(int id, LanguageMaster languageMaster)
        {
            if (id != languageMaster.LanguageId)
            {
                return BadRequest();
            }

            _context.Entry(languageMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageMasterExists(id))
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

        // POST: api/LanguageMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LanguageMaster>> PostLanguageMaster(LanguageMaster languageMaster)
        {
          if (_context.LanguageMasters == null)
          {
              return Problem("Entity set 'Ccontext.LanguageMasters'  is null.");
          }
            _context.LanguageMasters.Add(languageMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguageMaster", new { id = languageMaster.LanguageId }, languageMaster);
        }

        // DELETE: api/LanguageMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguageMaster(int id)
        {
            if (_context.LanguageMasters == null)
            {
                return NotFound();
            }
            var languageMaster = await _context.LanguageMasters.FindAsync(id);
            if (languageMaster == null)
            {
                return NotFound();
            }

            _context.LanguageMasters.Remove(languageMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanguageMasterExists(int id)
        {
            return (_context.LanguageMasters?.Any(e => e.LanguageId == id)).GetValueOrDefault();
        }
    }
}
