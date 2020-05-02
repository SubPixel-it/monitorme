using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("{controller}")]
    public class SysLogController : Controller
    {
        private readonly SysLogLogic sysLogLogic = new SysLogLogic();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(sysLogLogic.Get(whereClause: null));
        }
    }
}