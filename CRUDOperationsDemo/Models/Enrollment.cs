using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUDOperationsDemo.Models;

namespace School.Models
{
    [Table("Enrollment")]
    public class Enrollment
    {
        [Key]
        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "teacher")]
        [Column(TypeName = "varchar(250)")]

        public string Teacher { get; set; } = string.Empty;

        [Required]
        [Display(Name = "subject")]
        [Column(TypeName = "varchar(250)")]

        public string Subject { get; set; } = string.Empty;

        [Required]
        [Display(Name = "student")]
        [Column(TypeName = "varchar(250)")]

        public string Student { get; set; } = string.Empty;

    }
}
