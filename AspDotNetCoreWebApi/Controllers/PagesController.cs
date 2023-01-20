using AspDotNetCoreWebApi.Data;
using AspDotNetCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerCommon
    {
        private readonly ApiDbContext dbContext;

        public PagesController(ApiDbContext dbContext, ILogger<PagesController> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        // GET: api/pages
        [HttpGet]
        public async Task<IActionResult> GetPages()
        {
            return Ok(await dbContext.Pages.ToListAsync());
        }

        //GET: api/pages/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPage([FromRoute] int id)
        {
            var page = await dbContext.Pages.FindAsync(id);
            if (page != null)
            {
                return Ok(page);
            }
            return NotFound();
        }
        // POST: api/pages/
        [HttpPost]
        public async Task<IActionResult> AddPage(AddPageRequest req)
        {
            try
            {
                var page = new Page()
                {
                    Name = req.Name,
                    CreateDate = DateTime.Now
                };
                await dbContext.Pages.AddAsync(page);
                await dbContext.SaveChangesAsync();
                return Ok(page);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        // PUT: api/pages/
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePage([FromRoute] int id, UpdatePageRequest req)
        {
            try
            {
                var page = await dbContext.Pages.FindAsync(id);
                if (page != null)
                {
                    page.Name = req.Name;
                    await dbContext.SaveChangesAsync();

                    return Ok(page);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        // Delete: api/pages/
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePage([FromRoute] int id)
        {
            try
            {
                var page = await dbContext.Pages.FindAsync(id);
                if (page != null)
                {
                    dbContext.Remove(page);
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
