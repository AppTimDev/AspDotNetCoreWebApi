using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspDotNetCoreWebApi.Controllers
{
    [Route("api/sys")]
    [ApiController]
    public class SystemController : ControllerCommon
    {
        public SystemController(ILogger<SystemController> logger)
        {
            this.logger = logger;
        }

        //For self-use only
        // GET: api/sys/shutdown
        [HttpGet("shutdown")]
        public IActionResult Shutdown()
        {
            logger.LogInformation($"Shutdown computer!!");
            var psi = new ProcessStartInfo("shutdown", "/s /t 5 /f");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
            logger.LogInformation($"Shutdown computer end!!");
            return Ok(new { ok = 1 });
        }

        //For self-use only
        // GET: api/sys/restart
        [HttpGet("restart")]
        public IActionResult Restart()
        {
            logger.LogInformation($"Restart computer!!");
            var psi = new ProcessStartInfo("shutdown", "/r /t 5 /f");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
            logger.LogInformation($"Restart computer end!!");
            return Ok(new { ok = 1 });
        }
    }
}
