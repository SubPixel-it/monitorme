using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("{controller}")]
    public class MonitorController : Controller
    {
        private readonly MonitorLogic monitorLogic = new MonitorLogic();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(monitorLogic.Get(whereClause: null));
        }
    }
}