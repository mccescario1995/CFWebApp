using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_users")]
    public class Users
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("email", TypeName = "varchar(50)")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(20)")]
        public string Password { get; set; }

        [Required]
        [Column("roleid")]
        public int RoleId { get; set; }

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

        public virtual Roles Role { get; set; }
        public virtual UserProfiles UserProfile { get; set; }
        public virtual UserEmployments UserEmployment { get; set; }
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }
        public virtual ICollection<Feedbacks> Feedbacks { get; set; }

    }
}
