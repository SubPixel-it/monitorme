using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class MonitorService
    {
        public Monitor Add(Monitor monitor)
        {
            using (MMContext mmc = new MMContext())
            {
                try
                {
                    mmc.Add(monitor);
                    mmc.SaveChanges();
                    return monitor;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null) Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public Monitor Update(Monitor monitor)
        {
            using (MMContext mmc = new MMContext())
            {
                Monitor exists = mmc.Monitors
                    .SingleOrDefault(x => x.MonitorId == monitor.MonitorId);
                if (exists == null) return null;

                try
                {
                    exists.Name = monitor.Name;
                    exists.Status = monitor.Status;
                    exists.MonitorGroupId = monitor.MonitorGroupId;
                    exists.MaxInterval = monitor.MaxInterval;
                    exists.LastBeat = monitor.LastBeat;

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

        public bool Remove(Monitor monitor)
        {
            using (MMContext mmc = new MMContext())
            {
                Monitor exists = mmc.Monitors
                    .SingleOrDefault(x => x.MonitorId == monitor.MonitorId);
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

        public List<Monitor> Get(Expression<Func<Monitor, bool>> whereClause)
        {
            using (MMContext mmc = new MMContext())
            {
                if (whereClause == null)
                    return mmc.Monitors.AsNoTracking()
                        .ToList();

                return mmc.Monitors.AsNoTracking()
                    .Where(whereClause).ToList();
            }
        }
    }
}