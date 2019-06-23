using IHC.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Description { get; set; }
        [Required]
        public double ExpectedReveneu { get; set; }
        [Required]
        public ProjectState State { get; set; }
        public long ManagerId { get; set; }
        public Manager Manager { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Planning> Plannings { get; set; }

    }
}
