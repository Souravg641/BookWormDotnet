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
    public class ProductBeneficiaryMastersController : ControllerBase
    {
        private readonly Ccontext _context;

        public ProductBeneficiaryMastersController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/ProductBeneficiaryMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBeneficiaryMaster>>> GetProductBeneficiaryMasters()
        {
          if (_context.ProductBeneficiaryMasters == null)
          {
              return NotFound();
          }
            return await _context.ProductBeneficiaryMasters.ToListAsync();
        }

        // GET: api/ProductBeneficiaryMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBeneficiaryMaster>> GetProductBeneficiaryMaster(int id)
        {
          if (_context.ProductBeneficiaryMasters == null)
          {
              return NotFound();
          }
            var productBeneficiaryMaster = await _context.ProductBeneficiaryMasters.FindAsync(id);

            if (productBeneficiaryMaster == null)
            {
                return NotFound();
            }

            return productBeneficiaryMaster;
        }

        // PUT: api/ProductBeneficiaryMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductBeneficiaryMaster(int id, ProductBeneficiaryMaster productBeneficiaryMaster)
        {
            if (id != productBeneficiaryMaster.ProductBeneficiaryId)
            {
                return BadRequest();
            }

            _context.Entry(productBeneficiaryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductBeneficiaryMasterExists(id))
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

        // POST: api/ProductBeneficiaryMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductBeneficiaryMaster>> PostProductBeneficiaryMaster(ProductBeneficiaryMaster productBeneficiaryMaster)
        {
          if (_context.ProductBeneficiaryMasters == null)
          {
              return Problem("Entity set 'Ccontext.ProductBeneficiaryMasters'  is null.");
          }
            _context.ProductBeneficiaryMasters.Add(productBeneficiaryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductBeneficiaryMaster", new { id = productBeneficiaryMaster.ProductBeneficiaryId }, productBeneficiaryMaster);
        }

        // DELETE: api/ProductBeneficiaryMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductBeneficiaryMaster(int id)
        {
            if (_context.ProductBeneficiaryMasters == null)
            {
                return NotFound();
            }
            var productBeneficiaryMaster = await _context.ProductBeneficiaryMasters.FindAsync(id);
            if (productBeneficiaryMaster == null)
            {
                return NotFound();
            }

            _context.ProductBeneficiaryMasters.Remove(productBeneficiaryMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductBeneficiaryMasterExists(int id)
        {
            return (_context.ProductBeneficiaryMasters?.Any(e => e.ProductBeneficiaryId == id)).GetValueOrDefault();
        }
    }
}
