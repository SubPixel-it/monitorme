using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SysLogService
    {
        public Models.SysLog Add(Models.SysLog sysLog)
        {
            using (MMContext mmc = new MMContext())
            {
                try
                {
                    mmc.Add(sysLog);
                    mmc.SaveChanges();
                    return sysLog;
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

        public List<Models.SysLog> Get(Expression<Func<Models.SysLog, bool>> whereClause)
        {
            using (MMContext mmc = new MMContext())
            {
                if (whereClause == null)
                    return mmc.SysLogs.AsNoTracking()
                        .ToList();

                return mmc.SysLogs.AsNoTracking()
                    .Where(whereClause).ToList();
            }
        }
    }
}