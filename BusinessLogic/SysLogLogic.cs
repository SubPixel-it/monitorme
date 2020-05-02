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
        private readonly SysLogService sysLogService = new SysLogService();

        public SysLog Add(
            string message,
            SysLog.Severities severity)
        {
            SysLog sysLog = new SysLog
            {
                Message = message,
                Severity = severity,
                Timestamp = DateTime.UtcNow
            };

            return sysLogService.Add(sysLog);
        }

        public SysLog Get(string id)
        {
            Expression<Func<SysLog, bool>> whereClause = x => x.Id == id;
            return sysLogService.Get(whereClause).SingleOrDefault();
        }

        public List<SysLog> Get(SysLog.Severities severity)
        {
            Expression<Func<SysLog, bool>> whereClause = x => x.Severity == severity;
            return sysLogService.Get(whereClause);
        }

        public List<SysLog> Get(Expression<Func<SysLog, bool>> whereClause)
        {
            return sysLogService.Get(whereClause);
        }
    }
}