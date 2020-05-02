using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AlarmLogService
    {
        public Models.AlarmLog Add(Models.AlarmLog alarm)
        {
            using (MMContext mmc = new MMContext())
            {
                try
                {
                    mmc.Add(alarm);
                    mmc.SaveChanges();
                    return alarm;
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

        public List<Models.AlarmLog> Get(Expression<Func<Models.AlarmLog, bool>> whereClause)
        {
            using (MMContext mmc = new MMContext())
            {
                if (whereClause == null)
                    return mmc.AlarmLogs.AsNoTracking()
                        .ToList();

                return mmc.AlarmLogs.AsNoTracking()
                    .Where(whereClause).ToList();
            }
        }
    }
}