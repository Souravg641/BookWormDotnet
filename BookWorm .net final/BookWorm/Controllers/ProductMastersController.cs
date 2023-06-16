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
    public class ProductMastersController : ControllerBase
    {
        private readonly Ccontext _context;

        public ProductMastersController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/ProductMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductMaster>>> GetProductMasters()
        {
          if (_context.ProductMasters == null)
          {
              return NotFound();
          }
            return await _context.ProductMasters.ToListAsync();
        }

        // GET: api/ProductMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMaster>> GetProductMaster(int id)
        {
          if (_context.ProductMasters == null)
          {
              return NotFound();
          }
            var productMaster = await _context.ProductMasters.FindAsync(id);

            if (productMaster == null)
            {
                return NotFound();
            }

            return productMaster;
        }

        // GET: api/ProductMasters/5
        [HttpGet("/api/ProductsByType/{id}")]
        public async Task<ActionResult<List<ProductMaster>>> GetProductMasterByType(int id)
        {
            if (_context.ProductMasters == null)
            {
                return NotFound();
            }
            // var productMaster = await _context.ProductMasters.FindAsync(id);

            var query = from pm in _context.ProductMasters
                        join pmt in _context.ProductTypeMasters
                        on pm.TypeId equals pmt.TypeId
                        where pm.TypeId == id
                        select pm;
            var productMaster = await query.ToListAsync();

            if (productMaster == null)
            {
                return NotFound();
            }

            return Ok(productMaster);
        }

        [HttpGet("/api/ProductsByGenre/{id}")]
        public async Task<ActionResult<List<ProductMaster>>> GetProductMasterByGenre(int id)
        {
            if (_context.ProductMasters == null)
            {
                return NotFound();
            }

            var query = (from pm in _context.ProductMasters
                         join gm in _context.GenreMasters
                         on pm.GenreId equals gm.GenreId
                         where pm.GenreId == id
                         select pm);
            var productMaster = await query.ToListAsync();

            if (productMaster == null)
            {
                return NotFound();
            }

            return Ok(productMaster);
        }



        // PUT: api/ProductMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductMaster(int id, ProductMaster productMaster)
        {
            if (id != productMaster.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMasterExists(id))
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

        // POST: api/ProductMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductMaster>> PostProductMaster(ProductMaster productMaster)
        {
          if (_context.ProductMasters == null)
          {
              return Problem("Entity set 'Ccontext.ProductMasters'  is null.");
          }
            _context.ProductMasters.Add(productMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductMaster", new { id = productMaster.ProductId }, productMaster);
        }

        // DELETE: api/ProductMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductMaster(int id)
        {
            if (_context.ProductMasters == null)
            {
                return NotFound();
            }
            var productMaster = await _context.ProductMasters.FindAsync(id);
            if (productMaster == null)
            {
                return NotFound();
            }

            _context.ProductMasters.Remove(productMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductMasterExists(int id)
        {
            return (_context.ProductMasters?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
