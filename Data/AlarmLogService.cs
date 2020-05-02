using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AlarmLogService
    {
        public AlarmLog Add(AlarmLog alarm)
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
                    if (ex.InnerException != null) Console.WriteLine(ex.InnerException.Message);

                    return null;
                }
            }
        }

        public List<AlarmLog> Get(Expression<Func<AlarmLog, bool>> whereClause)
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