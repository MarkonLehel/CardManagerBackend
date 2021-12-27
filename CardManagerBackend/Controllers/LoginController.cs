using CardManagerBackend.Context;
using CardManagerBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CardManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> IdentifyUser([FromBody] JObject data)
        {
            string email = data["email"].ToString();
            string password = data["password"].ToString();
            bool adminLogin = data["adminLogin"].ToString()== "true" ? true: false;

            User user = null;
            foreach (User userToCheck in _context.Users.ToList())
            {
                if(userToCheck.Email == email)
                {
                    user = userToCheck;
                    break;
                }
            }

            if( user == null)
            {
                return NotFound();
            } else if (!user.CheckLoginCredentials(email, password)) {
                return ValidationProblem();
            } else if(adminLogin == user.IsAdmin){
                user.LastLogin = DateTime.UtcNow;
                return Ok(user.UserID);
            }
            else return ValidationProblem();

        }
    }
}
