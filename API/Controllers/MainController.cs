using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("{controller}")]
    public class MainController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("Welcome to MonitorMe APIs!");
        }
    }
}