using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Users.Helpers;

namespace Users.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<SignUp> UsersList = new List<SignUp>
        {
                new SignUp { id = Guid.NewGuid(), name = "John Doe", email = "ahmad@gmail.com",
                password = Hashing.HashPassword("123456") },
        };


        //Route to signup

        [HttpPost("signup")]
        public async Task<ActionResult<List<SignUp>>> Signup(SignUp user)
        {
            if (UsersList.Exists(registeredUser => registeredUser.email == user.email))
            {
                return BadRequest("Email already exists");
            }
            UsersList.Add(new SignUp
            {
                id = Guid.NewGuid(),
                name = user.name,
                email = user.email,
                password = Hashing.HashPassword(user.password)
            });
            return Ok(UsersList);
        }

        // Route to log-in
        [HttpPost("login")]
        public async Task<ActionResult<List<LogIn>>> Login(LogIn user)
        {
            if (UsersList.Exists(registeredUser => registeredUser.email == user.email && registeredUser.password == Hashing.HashPassword(user.password)))
            {
                return Ok("you are logged in");
            }
            return BadRequest("Invalid email or password");
        }
        [HttpGet]
        public async Task<ActionResult<List<SignUp>>> Get()
        {
            return Ok(UsersList);

        }

    }
}


