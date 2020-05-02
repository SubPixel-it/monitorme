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
        private readonly AlarmLogService alarmLogService = new AlarmLogService();

        public AlarmLog Add(
            string monitorId)
        {
            AlarmLog alarmLog = new AlarmLog
            {
                MonitorId = monitorId,
                Timestamp = DateTime.UtcNow
            };

            return alarmLogService.Add(alarmLog);
        }

        public AlarmLog Get(string id)
        {
            Expression<Func<AlarmLog, bool>> whereClause = x => x.Id == id;
            return alarmLogService.Get(whereClause).SingleOrDefault();
        }

        public List<AlarmLog> GetByMonitor(string monitorId)
        {
            Expression<Func<AlarmLog, bool>> whereClause = x => x.MonitorId == monitorId;
            return alarmLogService.Get(whereClause);
        }

        public List<AlarmLog> Get(Expression<Func<AlarmLog, bool>> whereClause)
        {
            return alarmLogService.Get(whereClause);
        }
    }
}