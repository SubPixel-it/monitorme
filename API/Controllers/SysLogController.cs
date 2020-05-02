using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("{controller}")]
    public class SysLogController : Controller
    {
        BusinessLogic.SysLogLogic sysLogLogic = new BusinessLogic.SysLogLogic();
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(sysLogLogic.Get(whereClause:null));
        }
    }
}