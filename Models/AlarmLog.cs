using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("log.AlarmLog")]
    public class AlarmLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public DateTime Timestamp { get; set; }
        public string MonitorId { get; set; }
        public virtual Monitor Monitor { get; set; }
    }
}