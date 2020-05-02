using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data;
using Models;

namespace BusinessLogic
{
    public class MonitorGroupLogic
    {
        MonitorGroupService monitorGroupService = new MonitorGroupService();
        
        public Models.MonitorGroup Add(
            string name,
            Monitor.State status)
        {
            Models.MonitorGroup monitorGroup = new MonitorGroup()
            {
                Name =  name,
                Status = status
            };
            
            return monitorGroupService.Add(monitorGroup);
        }
        public Models.MonitorGroup Update(
            string monitorGroupId,
            string name,
            Monitor.State status)
        {
            Models.MonitorGroup monitorGroup = new MonitorGroup()
            {
                MonitorGroupId = monitorGroupId,
                Name =  name,
                Status = status
            };
            
            return monitorGroupService.Update(monitorGroup);
        }
        public bool Remove(
            string monitorGroupId)
        {
            Models.MonitorGroup monitorGroup = new MonitorGroup()
            {
                MonitorGroupId = monitorGroupId
            };
            
            return monitorGroupService.Remove(monitorGroup);
        }
        
        public Models.MonitorGroup Get(string monitorGroupId)
        {
            Expression<Func<Models.MonitorGroup, bool>> whereClause = x => x.MonitorGroupId == monitorGroupId;
            return Get(whereClause).SingleOrDefault();
        }
        public Models.MonitorGroup Get(Monitor.State status)
        {
            Expression<Func<Models.MonitorGroup, bool>> whereClause = x => x.Status == status;
            return Get(whereClause).SingleOrDefault();
        }
        public List<Models.MonitorGroup> Get(Expression<Func<Models.MonitorGroup, bool>> whereClause)
        {
            return monitorGroupService.Get(whereClause);
        }
    }
}