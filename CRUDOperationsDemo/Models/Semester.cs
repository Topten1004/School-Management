using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    [Table("Semester")]
    public class Semester
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "ClientId")]
        [Column(TypeName = "int")]
        public int ClientId { get; set; } = 0;

        [Required]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "FromDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime FromDate { get; set; }

        [Required]
        [Display(Name = "EndDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "[Default]")]
        [Column(TypeName = "bit")]
        public bool Default { get; set; }

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


        [Required]
        [Display(Name = "Weeks")]
        [Column(TypeName = "int")]
        public int Weeks { get; set; } = 0;
    }
}
