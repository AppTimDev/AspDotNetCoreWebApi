using AspDotNetCoreWebApi.Data;
using AspDotNetCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerCommon
    {
        private readonly ApiDbContext dbContext;

        public UsersController(ApiDbContext dbContext, ILogger<UsersController> logger) {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetUsers() {
            return Ok(await dbContext.Users.ToListAsync());
        }

        //GET: api/users/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                return Ok(user);    
            }
            return NotFound();
        }

        // POST: api/users/
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest req)
        {
            try
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = req.Name,
                    Age = req.Age,
                    CreateDate = DateTime.Now
                };
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }            
        }

        // PUT: api/users/
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest req)
        {
            try
            {
                var user = await dbContext.Users.FindAsync(id);
                if (user != null)
                {
                    user.Name = req.Name;
                    user.Age = req.Age;

                    await dbContext.SaveChangesAsync();

                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        // Delete: api/users/
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            try
            {
                var user = await dbContext.Users.FindAsync(id);
                if (user != null)
                {
                    dbContext.Remove(user);
                    await dbContext.SaveChangesAsync();

                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
    }
}
