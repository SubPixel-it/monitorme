using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("log.SysLog")]
    public class SysLog
    {
        public enum Severities
        {
            Debug = 0,
            Info = 1,
            Warning = 2,
            Error = 3,
            Critical = 4
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public Severities Severity { get; set; }
        public string Message { get; set; }
    }
}