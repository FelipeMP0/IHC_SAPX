using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHC.Models
{
    [Table("JobRoles")]
    public class JobRole
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Level { get; set; }
        public ICollection<Planning> Plannings { get; set; }
    }
}
