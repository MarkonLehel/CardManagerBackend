using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardManagerBackend.Context;
using CardManagerBackend.Models;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace CardManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] JObject data)
        {
            int id = int.Parse(data["id"].ToString());
            string password = data["password"].ToString();
            User user = await _context.Users.FindAsync(id);

            user.ChangePassword(password);
           
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPut("ChangeName")]
        public async Task<IActionResult> ChangeName([FromBody] JObject data)
        {
            int id = int.Parse(data["id"].ToString());
            string firstName = data["firstName"].ToString();
            string lastName = data["firstName"].ToString();
            User user = await _context.Users.FindAsync(id);

            user.ChangeName(firstName,lastName);

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User userToAdd)
        {
            foreach (User user in _context.Users.ToList())
            {
                Debug.WriteLine(user.Email + "   " + userToAdd.Email);
                if (user.Email == userToAdd.Email) {
                    Debug.WriteLine("Conflict!");
                    return Conflict();
                }
            }
            userToAdd.ChangePassword(userToAdd.HashedPassword);
            userToAdd.LastLogin = DateTime.UtcNow;
            userToAdd.CreatedAt = DateTime.UtcNow;
            _context.Users.Add(userToAdd);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = userToAdd.UserID }, userToAdd);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
