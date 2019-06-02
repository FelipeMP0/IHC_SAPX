using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHC.Models
{
    [Table("Plannings")]
    public class Planning
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public JobRole JobRole { get; set; }
        [Required]
        public Project Project { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PlannedHours { get; set; }
    }
}
