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
    public class CustomerMastersController : ControllerBase
    {
        private readonly Ccontext _context;

        public CustomerMastersController(Ccontext context)
        {
            _context = context;
        }

        // GET: api/CustomerMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerMaster>>> GetCustomerMasters()
        {
            if (_context.CustomerMasters == null)
            {
                return NotFound();
            }
            return await _context.CustomerMasters.ToListAsync();
        }

        // GET: api/CustomerMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerMaster>> GetCustomerMaster(int id)
        {
            if (_context.CustomerMasters == null)
            {
                return NotFound();
            }
            var customerMaster = await _context.CustomerMasters.FindAsync(id);

            if (customerMaster == null)
            {
                return NotFound();
            }

            return customerMaster;
        }

        // PUT: api/CustomerMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerMaster(int id, CustomerMaster customerMaster)
        {
            if (id != customerMaster.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerMasterExists(id))
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

        // POST: api/CustomerMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerMaster>> PostCustomerMaster(CustomerMaster customerMaster)
        {
            if (_context.CustomerMasters == null)
            {
                return Problem("Entity set 'Ccontext.CustomerMasters'  is null.");
            }
            _context.CustomerMasters.Add(customerMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerMaster", new { id = customerMaster.CustomerId }, customerMaster);
        }

        // DELETE: api/CustomerMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerMaster(int id)
        {
            if (_context.CustomerMasters == null)
            {
                return NotFound();
            }
            var customerMaster = await _context.CustomerMasters.FindAsync(id);
            if (customerMaster == null)
            {
                return NotFound();
            }

            _context.CustomerMasters.Remove(customerMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerMasterExists(int id)
        {
            return (_context.CustomerMasters?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
