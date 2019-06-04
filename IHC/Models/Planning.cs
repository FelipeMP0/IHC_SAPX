using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHC.Models
{
    [Table("Plannings")]
    public class Planning
    {
        [Key]
        public long Id { get; set; }
        public long JobRoleId { get; set; }
        public JobRole JobRole { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PlannedHours { get; set; }
    }
}
