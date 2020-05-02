using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("{controller}")]
    public class MonitorGroupController : Controller
    {
        private readonly MonitorGroupLogic monitorGroupLogic = new MonitorGroupLogic();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(monitorGroupLogic.Get(whereClause: null));
        }
    }
}