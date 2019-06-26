using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHC.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public long Id { get; set; }
        [Required]
        //[Index("Idx_Customer_Document", 1, IsUnique = true)]
        [StringLength(15)]
        public string Document { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public ICollection<Project> Projects { get; set; }
        public bool Active { get; set; } = true;
    }
}
