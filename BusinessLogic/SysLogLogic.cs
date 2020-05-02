using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data;
using Models;

namespace BusinessLogic
{
    public class SysLogLogic
    {
        SysLogService sysLogService = new SysLogService();
        
        public Models.SysLog Add(
            string message,
            SysLog.Severities severity)
        {
            Models.SysLog sysLog = new SysLog()
            {
                Message = message,
                Severity =  severity,
                Timestamp = DateTime.UtcNow
            };
            
            return sysLogService.Add(sysLog);
        }

        public Models.SysLog Get(string id)
        {
            Expression<Func<Models.SysLog, bool>> whereClause = x => x.Id == id;
            return sysLogService.Get(whereClause).SingleOrDefault();
        }
        public List<Models.SysLog> Get(SysLog.Severities severity)
        {
            Expression<Func<Models.SysLog, bool>> whereClause = x => x.Severity == severity;
            return sysLogService.Get(whereClause);
        }
        public List<Models.SysLog> Get(Expression<Func<Models.SysLog, bool>> whereClause)
        {
            return sysLogService.Get(whereClause);
        }
    }
}