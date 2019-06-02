﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
