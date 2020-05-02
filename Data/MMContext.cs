using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Data
{
    // ReSharper disable once InconsistentNaming
    public class MMContext : DbContext
    {
        static string ConnectionString = @"Server=.;Database=MonitorMe;Trusted_Connection=True";
        public MMContext()
        { }
        
        public MMContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
        public MMContext(DbContextOptions<MMContext> options)
            : base(options)
        { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Models.MonitorGroup> MonitorGroups { get; set; }
        public DbSet<Models.Monitor> Monitors { get; set; }
        public DbSet<Models.AlarmLog> AlarmLogs { get; set; }
        public DbSet<Models.SysLog> SysLogs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}