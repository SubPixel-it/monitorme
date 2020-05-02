using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MonitorGroupService
    {
        public Models.MonitorGroup Add(Models.MonitorGroup monitorGroup)
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
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                    return null;
                }
            }
        }
        
        public Models.MonitorGroup Update(Models.MonitorGroup monitorGroup)
        {
            using (MMContext mmc = new MMContext())
            {
                Models.MonitorGroup exists = mmc.MonitorGroups
                    .SingleOrDefault(x => x.MonitorGroupId == monitorGroup.MonitorGroupId);
                if (exists == null)
                {
                    return null;
                }
                
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
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                    return null;
                }
            }
        }
        
        public bool Remove(Models.MonitorGroup monitorGroup)
        {
            using (MMContext mmc = new MMContext())
            {
                Models.MonitorGroup exists = mmc.MonitorGroups
                    .SingleOrDefault(x => x.MonitorGroupId == monitorGroup.MonitorGroupId);
                if (exists == null)
                {
                    return false;
                }
                
                try
                {
                    mmc.Remove(exists);
                    mmc.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                    return false;
                }
            }
        }
        
        public List<Models.MonitorGroup> Get(Expression<Func<Models.MonitorGroup, bool>> whereClause)
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