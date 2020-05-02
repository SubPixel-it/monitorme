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
        MonitorService monitorService = new MonitorService();
        
        public Models.Monitor Add(
            string name,
            int maxIntervalInSeconds,
            string monitorGroupId)
        {
            Models.Monitor monitor = new Monitor()
            {
                Name =  name,
                Status = Monitor.State.Deactivated,
                MonitorId = monitorGroupId,
                MaxInterval = new TimeSpan(0,0,0,maxIntervalInSeconds),
                LastBeat = DateTime.UtcNow
            };
            
            return monitorService.Add(monitor);
        }
        public Models.Monitor Update(
            string monitorId,
            string name,
            int maxIntervalInSeconds,
            string monitorGroupId,
            Monitor.State status)
        {
            Models.Monitor monitor = Get(monitorId);

            monitor.Name = name;
            monitor.Status = status;
            monitor.MonitorId = monitorGroupId;
            monitor.MaxInterval = new TimeSpan(0, 0, 0, maxIntervalInSeconds);
            
            return monitorService.Update(monitor);
        }
        public bool Remove(
            string monitorId)
        {
            Models.Monitor monitor = new Monitor()
            {
                MonitorId = monitorId
            };
            
            return monitorService.Remove(monitor);
        }
        public Models.Monitor HeartBeat(
            string monitorId)
        {
            Models.Monitor monitor = Get(monitorId);
            if (monitor == null)
            {
                return null;
            }
            monitor.LastBeat = DateTime.UtcNow;
            
            return monitorService.Update(monitor);
        }
        
        public Models.Monitor Get(string monitorId)
        {
            Expression<Func<Models.Monitor, bool>> whereClause = x => x.MonitorId == monitorId;
            return Get(whereClause).SingleOrDefault();
        }
        public List<Models.Monitor> GetByGroup(string monitorGroupId)
        {
            Expression<Func<Models.Monitor, bool>> whereClause = x => x.MonitorGroupId == monitorGroupId;
            return Get(whereClause);
        }
        public Models.Monitor Get(Monitor.State status)
        {
            Expression<Func<Models.Monitor, bool>> whereClause = x => x.Status == status;
            return Get(whereClause).SingleOrDefault();
        }
        public List<Models.Monitor> Get(Expression<Func<Models.Monitor, bool>> whereClause)
        {
            return monitorService.Get(whereClause);
        }
    }
}