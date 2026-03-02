using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloraBack.api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet(template:"ping")]
        
        public IActionResult Ping()
        {
            return Ok("popong");
        }
    }
}
