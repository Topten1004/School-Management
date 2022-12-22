using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDOperationsDemo.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "PeriodCount")]
        [Column(TypeName = "int")]
        public int PeriodCount { get; set; } = 0;

        [Required]
        [Display(Name = "DateCreated")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "DateModified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime DateModified { get; set; }

    }
}
