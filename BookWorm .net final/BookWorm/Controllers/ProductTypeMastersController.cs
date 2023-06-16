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
    public class ProductTypeMastersController : ControllerBase
    {
        private readonly Ccontext _context;

        public ProductTypeMastersController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/ProductTypeMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTypeMaster>>> GetProductTypeMasters()
        {
          if (_context.ProductTypeMasters == null)
          {
              return NotFound();
          }
            return await _context.ProductTypeMasters.ToListAsync();
        }

        // GET: api/ProductTypeMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeMaster>> GetProductTypeMaster(int id)
        {
          if (_context.ProductTypeMasters == null)
          {
              return NotFound();
          }
            var productTypeMaster = await _context.ProductTypeMasters.FindAsync(id);

            if (productTypeMaster == null)
            {
                return NotFound();
            }

            return productTypeMaster;
        }

        // PUT: api/ProductTypeMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTypeMaster(int id, ProductTypeMaster productTypeMaster)
        {
            if (id != productTypeMaster.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(productTypeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeMasterExists(id))
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

        // POST: api/ProductTypeMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTypeMaster>> PostProductTypeMaster(ProductTypeMaster productTypeMaster)
        {
          if (_context.ProductTypeMasters == null)
          {
              return Problem("Entity set 'Ccontext.ProductTypeMasters'  is null.");
          }
            _context.ProductTypeMasters.Add(productTypeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTypeMaster", new { id = productTypeMaster.TypeId }, productTypeMaster);
        }

        // DELETE: api/ProductTypeMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTypeMaster(int id)
        {
            if (_context.ProductTypeMasters == null)
            {
                return NotFound();
            }
            var productTypeMaster = await _context.ProductTypeMasters.FindAsync(id);
            if (productTypeMaster == null)
            {
                return NotFound();
            }

            _context.ProductTypeMasters.Remove(productTypeMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTypeMasterExists(int id)
        {
            return (_context.ProductTypeMasters?.Any(e => e.TypeId == id)).GetValueOrDefault();
        }
    }
}
