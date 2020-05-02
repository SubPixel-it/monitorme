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
        private readonly MonitorGroupService monitorGroupService = new MonitorGroupService();

        public MonitorGroup Add(
            string name,
            Monitor.State status)
        {
            MonitorGroup monitorGroup = new MonitorGroup
            {
                Name = name,
                Status = status
            };

            return monitorGroupService.Add(monitorGroup);
        }

        public MonitorGroup Update(
            string monitorGroupId,
            string name,
            Monitor.State status)
        {
            MonitorGroup monitorGroup = new MonitorGroup
            {
                MonitorGroupId = monitorGroupId,
                Name = name,
                Status = status
            };

            return monitorGroupService.Update(monitorGroup);
        }

        public bool Remove(
            string monitorGroupId)
        {
            MonitorGroup monitorGroup = new MonitorGroup
            {
                MonitorGroupId = monitorGroupId
            };

            return monitorGroupService.Remove(monitorGroup);
        }

        public MonitorGroup Get(string monitorGroupId)
        {
            Expression<Func<MonitorGroup, bool>> whereClause = x => x.MonitorGroupId == monitorGroupId;
            return Get(whereClause).SingleOrDefault();
        }

        public MonitorGroup Get(Monitor.State status)
        {
            Expression<Func<MonitorGroup, bool>> whereClause = x => x.Status == status;
            return Get(whereClause).SingleOrDefault();
        }

        public List<MonitorGroup> Get(Expression<Func<MonitorGroup, bool>> whereClause)
        {
            return monitorGroupService.Get(whereClause);
        }
    }
}