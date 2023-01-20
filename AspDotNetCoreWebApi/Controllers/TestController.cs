using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerCommon
    {
        public TestController(ILogger<TestController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            logger.LogInformation("test");
            return Ok("test");
        }

        [HttpGet("timeout")]
        public async Task<IActionResult> TestTimeout(int sec = 5)
        {
            try
            {
                logger.LogInformation($"Test timeout {sec}");
                //will respose after some seconds
                await Task.Delay(TimeSpan.FromSeconds(sec));
                logger.LogInformation($"Test timeout {sec} completed.");
                return Ok(new { method = "get", ok = 1, delay=$"{sec} seconds" });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "TestTimeout Exception");
                return Ok("Exception");
            }
        }
    }
}
