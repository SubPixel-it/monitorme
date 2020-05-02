using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("{controller}")]
    public class MonitorGroupController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("MonitorGroup API Controller");
        }
    }
}