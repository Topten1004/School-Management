using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    [Table("SubjectAttendance")]
    public class SubjectAttendance
    {
        [Key]
        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "SubjectId")]
        [Column(TypeName = "int")]
        public int SubjectId { get; set; } = 0;

        [Required]
        [Display(Name = "TeacherId")]
        [Column(TypeName = "int")]
        public int TeacherId { get; set; } = 0;

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Period")]
        [Column(TypeName = "int")]
        public int Period { get; set; } = 0;

        [Required]
        [Display(Name = "PeriodTimeOfDay")]
        [Column(TypeName = "int")]
        public int PeriodTimeOfDay { get; set; } = 0;
    }
}
