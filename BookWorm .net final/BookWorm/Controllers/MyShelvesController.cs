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
    public class MyShelvesController : ControllerBase
    {
        private readonly Ccontext _context;

        public MyShelvesController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/MyShelves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyShelf>>> GetMyShelfs()
        {
          if (_context.MyShelfs == null)
          {
              return NotFound();
          }
            return await _context.MyShelfs.ToListAsync();
        }

        // GET: api/MyShelves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyShelf>> GetMyShelf(int id)
        {
          if (_context.MyShelfs == null)
          {
              return NotFound();
          }
            var myShelf = await _context.MyShelfs.FindAsync(id);

            if (myShelf == null)
            {
                return NotFound();
            }

            return myShelf;
        }

        // PUT: api/MyShelves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyShelf(int id, MyShelf myShelf)
        {
            if (id != myShelf.ShelfId)
            {
                return BadRequest();
            }

            _context.Entry(myShelf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyShelfExists(id))
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

        // POST: api/MyShelves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyShelf>> PostMyShelf(MyShelf myShelf)
        {
          if (_context.MyShelfs == null)
          {
              return Problem("Entity set 'Ccontext.MyShelfs'  is null.");
          }
            _context.MyShelfs.Add(myShelf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyShelf", new { id = myShelf.ShelfId }, myShelf);
        }

        // DELETE: api/MyShelves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyShelf(int id)
        {
            if (_context.MyShelfs == null)
            {
                return NotFound();
            }
            var myShelf = await _context.MyShelfs.FindAsync(id);
            if (myShelf == null)
            {
                return NotFound();
            }

            _context.MyShelfs.Remove(myShelf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyShelfExists(int id)
        {
            return (_context.MyShelfs?.Any(e => e.ShelfId == id)).GetValueOrDefault();
        }
    }
}
