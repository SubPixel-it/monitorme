using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    // ReSharper disable once InconsistentNaming
    public class MMContext : DbContext
    {
        private static string ConnectionString = @"Server=.;Database=MonitorMe;Trusted_Connection=True";

        public MMContext()
        {
        }

        public MMContext(string connectionString)
        {
            ConnectionString = connectionString;
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
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}