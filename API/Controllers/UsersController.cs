using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        //When a user makes a query using the above Route https://localhost:5001/api/users
        //The UsersController class will be created. Any dependencies we have within the constructor will be created.
        public UsersController(DataContext context)
        {
            _context = context;

        }

        //An action result is what a controller action returns in response to a browser request. 
        [HttpGet] //This is going to be a HttpGet that = Get /api/users
        //Using ActionResult gives us the ability to return the Http request, either good or bad
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //The method gets all of the users from AppUser and returns a list of the users
            //The _context is the DataContext class which then calls the Users method that will get the Users from the AppUser class
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")] //https://localhost:5001/api/users/{id}
        public async Task<ActionResult<AppUser>> getUser(int id)
        {
            //The find method uses the primary key to find the user in the table and returns the user 
            return await _context.Users.FindAsync(id);


        }
    }
}