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
    public class BeneficiaryMastersController : ControllerBase
    {
        private readonly Ccontext _context;

        public BeneficiaryMastersController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/BeneficiaryMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeneficiaryMaster>>> GetBeneficiaryMasters()
        {
          if (_context.BeneficiaryMasters == null)
          {
              return NotFound();
          }
            return await _context.BeneficiaryMasters.ToListAsync();
        }

        // GET: api/BeneficiaryMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeneficiaryMaster>> GetBeneficiaryMaster(int id)
        {
          if (_context.BeneficiaryMasters == null)
          {
              return NotFound();
          }
            var beneficiaryMaster = await _context.BeneficiaryMasters.FindAsync(id);

            if (beneficiaryMaster == null)
            {
                return NotFound();
            }

            return beneficiaryMaster;
        }

        // PUT: api/BeneficiaryMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficiaryMaster(int id, BeneficiaryMaster beneficiaryMaster)
        {
            if (id != beneficiaryMaster.BeneficiaryId)
            {
                return BadRequest();
            }

            _context.Entry(beneficiaryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiaryMasterExists(id))
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

        // POST: api/BeneficiaryMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BeneficiaryMaster>> PostBeneficiaryMaster(BeneficiaryMaster beneficiaryMaster)
        {
          if (_context.BeneficiaryMasters == null)
          {
              return Problem("Entity set 'Ccontext.BeneficiaryMasters'  is null.");
          }
            _context.BeneficiaryMasters.Add(beneficiaryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficiaryMaster", new { id = beneficiaryMaster.BeneficiaryId }, beneficiaryMaster);
        }

        // DELETE: api/BeneficiaryMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficiaryMaster(int id)
        {
            if (_context.BeneficiaryMasters == null)
            {
                return NotFound();
            }
            var beneficiaryMaster = await _context.BeneficiaryMasters.FindAsync(id);
            if (beneficiaryMaster == null)
            {
                return NotFound();
            }

            _context.BeneficiaryMasters.Remove(beneficiaryMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficiaryMasterExists(int id)
        {
            return (_context.BeneficiaryMasters?.Any(e => e.BeneficiaryId == id)).GetValueOrDefault();
        }
    }
}
