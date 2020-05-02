using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("{controller}")]
    public class MonitorController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("Monitor API Controller");
        }
    }
}