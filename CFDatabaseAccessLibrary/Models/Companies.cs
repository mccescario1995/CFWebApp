using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_companies")]
    public class Companies
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("companyname", TypeName = "varchar(200)")]
        public string CompanyName { get; set; }

        [Required]
        [Column("companycode", TypeName = "varchar(50)")]
        public string CompanyCode { get; set; }

        [Column("industry", TypeName = "varchar(100)")]
        public string Industry { get; set; }

        [Column("companysize", TypeName = "varchar(50)")]
        public string CompanySize { get; set; } // Small, Medium, Large, Enterprise

        [Column("website", TypeName = "varchar(255)")]
        [Url]
        public string Website { get; set; }

        [Required]
        [Column("status")]
        public byte Status { get; set; } = 1;

        [Required]
        [Column("isdelete")]
        public byte Isdelete { get; set; } = 0;

        [Required]
        [Column("createdbyuserid")]
        public int Createdbyuserid { get; set; }

        [Required]
        [Column("createddate")]
        public DateTime Createddate { get; set; }

        [Required]
        [Column("modefiedbyuserid")]
        public int Modefiedbyuserid { get; set; }

        [Required]
        [Column("modefieddate")]
        public DateTime Modefieddate { get; set; }

        public virtual ICollection<UserEmployments> UserEmployments { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
    }
}
