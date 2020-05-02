using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class SysLogService
    {
        public SysLog Add(SysLog sysLog)
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
                    if (ex.InnerException != null) Console.WriteLine(ex.InnerException.Message);

                    return null;
                }
            }
        }

        public List<SysLog> Get(Expression<Func<SysLog, bool>> whereClause)
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