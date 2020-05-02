using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("dbo.MonitorGroup")]
    public class MonitorGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MonitorGroupId { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public Monitor.State Status { get; set; }
    }
}