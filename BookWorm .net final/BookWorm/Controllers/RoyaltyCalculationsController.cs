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
    public class RoyaltyCalculationsController : ControllerBase
    {
        private readonly Ccontext _context;

        public RoyaltyCalculationsController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/RoyaltyCalculations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoyaltyCalculation>>> GetRoyaltyCalculations()
        {
          if (_context.RoyaltyCalculations == null)
          {
              return NotFound();
          }
            return await _context.RoyaltyCalculations.ToListAsync();
        }

        // GET: api/RoyaltyCalculations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoyaltyCalculation>> GetRoyaltyCalculation(int id)
        {
          if (_context.RoyaltyCalculations == null)
          {
              return NotFound();
          }
            var royaltyCalculation = await _context.RoyaltyCalculations.FindAsync(id);

            if (royaltyCalculation == null)
            {
                return NotFound();
            }

            return royaltyCalculation;
        }

        // PUT: api/RoyaltyCalculations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoyaltyCalculation(int id, RoyaltyCalculation royaltyCalculation)
        {
            if (id != royaltyCalculation.RoyaltyCalculationId)
            {
                return BadRequest();
            }

            _context.Entry(royaltyCalculation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoyaltyCalculationExists(id))
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

        // POST: api/RoyaltyCalculations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoyaltyCalculation>> PostRoyaltyCalculation(RoyaltyCalculation royaltyCalculation)
        {
          if (_context.RoyaltyCalculations == null)
          {
              return Problem("Entity set 'Ccontext.RoyaltyCalculations'  is null.");
          }
            _context.RoyaltyCalculations.Add(royaltyCalculation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoyaltyCalculation", new { id = royaltyCalculation.RoyaltyCalculationId }, royaltyCalculation);
        }

        // DELETE: api/RoyaltyCalculations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoyaltyCalculation(int id)
        {
            if (_context.RoyaltyCalculations == null)
            {
                return NotFound();
            }
            var royaltyCalculation = await _context.RoyaltyCalculations.FindAsync(id);
            if (royaltyCalculation == null)
            {
                return NotFound();
            }

            _context.RoyaltyCalculations.Remove(royaltyCalculation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoyaltyCalculationExists(int id)
        {
            return (_context.RoyaltyCalculations?.Any(e => e.RoyaltyCalculationId == id)).GetValueOrDefault();
        }
    }
}
