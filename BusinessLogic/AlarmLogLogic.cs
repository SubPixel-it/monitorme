using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data;
using Models;

namespace BusinessLogic
{
    public class AlarmLogLogic
    {
        AlarmLogService alarmLogService = new AlarmLogService();
        
        public Models.AlarmLog Add(
            string monitorId)
        {
            Models.AlarmLog alarmLog = new AlarmLog()
            {
                MonitorId = monitorId,
                Timestamp = DateTime.UtcNow
            };
            
            return alarmLogService.Add(alarmLog);
        }

        public Models.AlarmLog Get(string id)
        {
            Expression<Func<Models.AlarmLog, bool>> whereClause = x => x.Id == id;
            return alarmLogService.Get(whereClause).SingleOrDefault();
        }
        public List<Models.AlarmLog> GetByMonitor(string monitorId)
        {
            Expression<Func<Models.AlarmLog, bool>> whereClause = x => x.MonitorId == monitorId;
            return alarmLogService.Get(whereClause);
        }
        public List<Models.AlarmLog> Get(Expression<Func<Models.AlarmLog, bool>> whereClause)
        {
            return alarmLogService.Get(whereClause);
        }
    }
}