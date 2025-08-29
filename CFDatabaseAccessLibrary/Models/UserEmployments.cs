using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_useremployments")]
    public class UserEmployments
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("userid")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]

        [Column("companyid")]
        public int? CompanyId { get; set; }

        [Column("departmentid")]
        public int? DepartmentId { get; set; }

        [Column("jobtitle", TypeName = "varchar(100)")]
        public string JobTitle { get; set; }

        [Column("employeeid", TypeName = "varchar(50)")]
        public string EmployeeId { get; set; }

        [Required]
        [Column("startdate")]
        public string Startdate { get; set; }

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

        public virtual Users User { get; set; }
        public virtual Companies Company { get; set; }
        public virtual Departments Department { get; set; }
    }
}
