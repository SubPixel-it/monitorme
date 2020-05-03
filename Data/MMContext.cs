using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    // ReSharper disable once InconsistentNaming
    public class MMContext : DbContext
    {
        private static string connectionString = @"Server=.;Database=MonitorMe;Trusted_Connection=False;user id=-;password=-";

        public MMContext()
        {
        }

        public MMContext(string connectionString)
        {
            connectionString = connectionString;
        }

        public MMContext(DbContextOptions<MMContext> options)
            : base(options)
        {
        }

        public DbSet<MonitorGroup> MonitorGroups { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<AlarmLog> AlarmLogs { get; set; }
        public DbSet<SysLog> SysLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}