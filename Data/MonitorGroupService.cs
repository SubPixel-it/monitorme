using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class MonitorGroupService
    {
        public MonitorGroup Add(MonitorGroup monitorGroup)
        {
            using (MMContext mmc = new MMContext())
            {
                try
                {
                    mmc.Add(monitorGroup);
                    mmc.SaveChanges();
                    return monitorGroup;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null) Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public MonitorGroup Update(MonitorGroup monitorGroup)
        {
            using (MMContext mmc = new MMContext())
            {
                MonitorGroup exists = mmc.MonitorGroups
                    .SingleOrDefault(x => x.MonitorGroupId == monitorGroup.MonitorGroupId);
                if (exists == null) return null;

                try
                {
                    exists.Name = monitorGroup.Name;
                    exists.Status = monitorGroup.Status;

                    mmc.SaveChanges();
                    return exists;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null) Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public bool Remove(MonitorGroup monitorGroup)
        {
            using (MMContext mmc = new MMContext())
            {
                MonitorGroup exists = mmc.MonitorGroups
                    .SingleOrDefault(x => x.MonitorGroupId == monitorGroup.MonitorGroupId);
                if (exists == null) return false;

                try
                {
                    mmc.Remove(exists);
                    mmc.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null) Console.WriteLine(ex.InnerException.Message);
                    return false;
                }
            }
        }

        public List<MonitorGroup> Get(Expression<Func<MonitorGroup, bool>> whereClause)
        {
            using (MMContext mmc = new MMContext())
            {
                if (whereClause == null)
                    return mmc.MonitorGroups.AsNoTracking()
                        .ToList();

                return mmc.MonitorGroups.AsNoTracking()
                    .Where(whereClause).ToList();
            }
        }
    }
}