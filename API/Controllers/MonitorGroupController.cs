using System;
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
        
        [HttpGet]
        [Route("{monitorGroupId}")]
        public IActionResult GetById(string monitorGroupId)
        {
            return Json(monitorGroupLogic.Get(monitorGroupId));
        }
        
        [HttpPost]
        public IActionResult Add()
        {
            string name = HttpContext.Request.Form["name"];
            string statusString = HttpContext.Request.Form["status"];

                if (String.IsNullOrEmpty(name) ||
                String.IsNullOrEmpty(statusString))
            {
                return new BadRequestObjectResult("Name or status is null or empty.")
                {
                    StatusCode = 411
                };
            }

            bool isInt = int.TryParse(statusString, out int status);
            if (!isInt)
            {
                return new BadRequestObjectResult("Status format not valid. Please use integer.")
                {
                    StatusCode = 411
                };
            }

            Models.MonitorGroup monitorGroup = monitorGroupLogic.Add(name, (Models.Monitor.State) status);
            if (monitorGroup == null)
            {
                return BadRequest("Something went wrong :(");
            }

            return Json(monitorGroup);
        }
        
        [HttpPatch]
        [Route("{monitorGroupId}")]
        public IActionResult Update(string monitorGroupId)
        {
            string name = HttpContext.Request.Form["name"];
            string statusString = HttpContext.Request.Form["status"];

            if (String.IsNullOrEmpty(name) ||
                String.IsNullOrEmpty(statusString))
            {
                return new BadRequestObjectResult("Name or status is null or empty.")
                {
                    StatusCode = 411
                };
            }

            bool isInt = int.TryParse(statusString, out int status);
            if (!isInt)
            {
                return new BadRequestObjectResult("Status format not valid. Please use integer.")
                {
                    StatusCode = 411
                };
            }

            Models.MonitorGroup monitorGroup = monitorGroupLogic.Update(monitorGroupId, name,
                (Models.Monitor.State) status);
            if (monitorGroup == null)
            {
                return BadRequest("Something went wrong :(");
            }

            return Json(monitorGroup);
        }
    }
}