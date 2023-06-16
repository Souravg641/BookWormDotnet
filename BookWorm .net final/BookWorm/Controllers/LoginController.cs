using BookWorm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace BookWorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly Ccontext _context;

        public LoginController(Ccontext context)
        {
            _context = context;
        }



        // POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CustomerMaster>>> PostLogin(Login login)
        {
            if (login == null)
            {
                return Problem("Enter Data to Login");
            }


            var customer = await _context.CustomerMasters.FirstOrDefaultAsync((customer) => customer.Email == login.Email && customer.Password == login.Password);

            if (login.Email.Equals(customer.Email) && login.Password.Equals(customer.Password))
            {
                return Ok(customer);
            }


            return BadRequest("Invalid PhoneNo. OR Password");
        }
    }

    public class Login
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }


}