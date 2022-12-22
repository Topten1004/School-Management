using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    [Table("SemesterAchrayus")]
    public class SemesterAchrayus
    {
        [Key]
        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "StudentID")]
        [Column(TypeName = "int")]
        public int StudentID { get; set; } = 0;

        [Required]
        [Display(Name = "Email")]
        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; } = String.Empty;

        [Required]
        [Display(Name = "SemesterName")]
        [Column(TypeName = "nvarchar(255)")]
        public string SemesterName { get; set; } = String.Empty;

        [Required]
        [Display(Name = "Achrayus")]
        [Column(TypeName = "int")]
        public int Achrayus { get; set; } = 0;
    }
}
