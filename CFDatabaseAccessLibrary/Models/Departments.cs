using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_departments")]
    public class Departments
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Column("companyid")]
        public int? CompanyId { get; set; }

        [Required]
        [Column("departmentname", TypeName = "varchar(100)")]
        public string DepartmentName { get; set; }

        [Column("departmentcode", TypeName = "varchar(20)")]
        public string DepartmentCode { get; set; }

        [Column("manageruserid")]
        public int? ManagerUserId { get; set; }

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

        public virtual Companies Company { get; set; }
        public virtual Users ManagerUser { get; set; }
        public virtual ICollection<UserEmployments> UserEmployments { get; set; }
    }
}
