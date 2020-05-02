using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data;
using Models;

namespace BusinessLogic
{
    public class MonitorLogic
    {
        private readonly MonitorService monitorService = new MonitorService();

        public Monitor Add(
            string name,
            int maxIntervalInSeconds,
            string monitorGroupId)
        {
            Monitor monitor = new Monitor
            {
                Name = name,
                Status = Monitor.State.Deactivated,
                MonitorId = monitorGroupId,
                MaxInterval = new TimeSpan(0, 0, 0, maxIntervalInSeconds),
                LastBeat = DateTime.UtcNow
            };

            return monitorService.Add(monitor);
        }

        public Monitor Update(
            string monitorId,
            string name,
            int maxIntervalInSeconds,
            string monitorGroupId,
            Monitor.State status)
        {
            Monitor monitor = Get(monitorId);

            monitor.Name = name;
            monitor.Status = status;
            monitor.MonitorId = monitorGroupId;
            monitor.MaxInterval = new TimeSpan(0, 0, 0, maxIntervalInSeconds);

            return monitorService.Update(monitor);
        }

        public bool Remove(
            string monitorId)
        {
            Monitor monitor = new Monitor
            {
                MonitorId = monitorId
            };

            return monitorService.Remove(monitor);
        }

        public Monitor HeartBeat(
            string monitorId)
        {
            Monitor monitor = Get(monitorId);
            if (monitor == null) return null;
            monitor.LastBeat = DateTime.UtcNow;

            return monitorService.Update(monitor);
        }

        public Monitor Get(string monitorId)
        {
            Expression<Func<Monitor, bool>> whereClause = x => x.MonitorId == monitorId;
            return Get(whereClause).SingleOrDefault();
        }

        public List<Monitor> GetByGroup(string monitorGroupId)
        {
            Expression<Func<Monitor, bool>> whereClause = x => x.MonitorGroupId == monitorGroupId;
            return Get(whereClause);
        }

        public Monitor Get(Monitor.State status)
        {
            Expression<Func<Monitor, bool>> whereClause = x => x.Status == status;
            return Get(whereClause).SingleOrDefault();
        }

        public List<Monitor> Get(Expression<Func<Monitor, bool>> whereClause)
        {
            return monitorService.Get(whereClause);
        }
    }
}