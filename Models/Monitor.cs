using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("dbo.MonitorGroup")]
    public class Monitor
    {
        public enum State
        {
            Alarm = -1,
            Deactivated = 0,
            Active = 1
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MonitorId { get; set; }

        [MaxLength(30)] public string Name { get; set; }

        public State Status { get; set; }
        public TimeSpan MaxInterval { get; set; }
        public DateTime LastBeat { get; set; }
        public string MonitorGroupId { get; set; }
        public virtual MonitorGroup MonitorGroup { get; set; }
    }
}