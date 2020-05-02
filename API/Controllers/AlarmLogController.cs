using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("{controller}")]
    public class AlarmLogController : Controller
    {
        AlarmLogLogic alarmLogLogic = new AlarmLogLogic();
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(alarmLogLogic.Get(whereClause:null));
        }
        
        [HttpGet]
        public IActionResult Get(string monitorId)
        {
            return Json(alarmLogLogic.GetByMonitor(monitorId));
        }
    }
}