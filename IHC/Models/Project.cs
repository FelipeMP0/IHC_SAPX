using IHC.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHC.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public double ExpectedReveneu { get; set; }
        [Required]
        public ProjectState State { get; set; }
        [Required]
        public Manager Manager { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public ICollection<Planning> Plannings { get; set; }

    }
}
