using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDOperationsDemo.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "ClientId")]
        [Column(TypeName = "int")]
        public int ClientId { get; set; } = 0;


        [Required]
        [Display(Name = "FirstName")]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "LastName")]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Title")]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Email")]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Password")]
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; } = string.Empty;

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
