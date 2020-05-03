using System;
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
        
        [HttpGet]
        [Route("{monitorId}")]
        public IActionResult GetById(string monitorId)
        {
            return Json(monitorLogic.Get(monitorId));
        }

        [HttpGet]
        [Route("group/{monitorGroupId}")]
        public IActionResult GetByGroup(string monitorGroupId)
        {
            return Json(monitorLogic.GetByGroup(monitorGroupId));
        }
        
        [HttpPost]
        public IActionResult Add()
        {
            string name = HttpContext.Request.Form["name"];
            string maxIntervalString = HttpContext.Request.Form["maxInterval"];
            string monitorGroupId = HttpContext.Request.Form["groupId"];

            if (String.IsNullOrEmpty(name) ||
                String.IsNullOrEmpty(maxIntervalString) ||
                (String.IsNullOrEmpty(monitorGroupId) && monitorGroupId != ""))
            {
                return new BadRequestObjectResult("A required parameter is null or empty.")
                {
                    StatusCode = 411
                };
            }

            bool isInt = int.TryParse(maxIntervalString, out int maxInterval);
            if (!isInt)
            {
                return new BadRequestObjectResult("maxInterval format not valid. Please use integer.")
                {
                    StatusCode = 411
                };
            }

            Models.Monitor monitor = monitorLogic.Add(name, maxInterval, monitorGroupId == "" ? null : monitorGroupId);
            if (monitor == null)
            {
                return BadRequest("Something went wrong :(");
            }

            return Json(monitor);
        }
        
        [HttpPatch]
        [Route("{monitorId}")]
        public IActionResult Update(string monitorId)
        {
            string name = HttpContext.Request.Form["name"];
            string maxIntervalString = HttpContext.Request.Form["maxInterval"];
            string monitorGroupId = HttpContext.Request.Form["groupId"];
            string statusString = HttpContext.Request.Form["status"];

            if (String.IsNullOrEmpty(name) ||
                String.IsNullOrEmpty(maxIntervalString) ||
                String.IsNullOrEmpty(statusString) ||
                (String.IsNullOrEmpty(monitorGroupId) && monitorGroupId != ""))
            {
                return new BadRequestObjectResult("A required parameter is null or empty.")
                {
                    StatusCode = 411
                };
            }

            bool isInt = int.TryParse(maxIntervalString, out int maxInterval);
            if (!isInt)
            {
                return new BadRequestObjectResult("maxInterval format not valid. Please use integer.")
                {
                    StatusCode = 411
                };
            }
            isInt = int.TryParse(statusString, out int status);
            if (!isInt)
            {
                return new BadRequestObjectResult("Status format not valid. Please use integer.")
                {
                    StatusCode = 411
                };
            }

            Models.Monitor monitor = monitorLogic.Update(monitorId, name, maxInterval,
                monitorGroupId == "" ? null : monitorGroupId, (Models.Monitor.State) status);
            if (monitor == null)
            {
                return BadRequest("Something went wrong :(");
            }

            return Json(monitor);
        }
        
        [HttpPatch]
        [Route("beat/{monitorId}")]
        public IActionResult Beat(string monitorId)
        {
            Models.Monitor monitor = monitorLogic.HeartBeat(monitorId);
            if (monitor == null)
            {
                return BadRequest("Something went wrong :(");
            }

            return Json(monitor);
        }
    }
}