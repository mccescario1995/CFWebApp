using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_userprofiles")]
    public class UserProfiles
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("userid")]
        public int UserId { get; set; }

        [MaxLength(100)]
        [Column("jobtitle")]
        public string? JobTitle { get; set; }

        [MaxLength(100)]
        [Column("department")]
        public string? Department { get; set; }

        [Column("companyid")]
        public int? CompanyId { get; set; }

        [MaxLength(500)]
        [Column("bio")]
        public string? Bio { get; set; }

        [MaxLength(255)]
        [Column("profileimageurl")]
        public string? ProfileImageUrl { get; set; }

        [Required]
        [Column("status")]
        public byte Status { get; set; } = 1;

        [Required]
        [Column("isdelete")]
        public byte IsDelete { get; set; } = 0;

        [Required]
        [Column("createdbyuserid")]
        public int CreatedByUserId { get; set; }

        [Required]
        [Column("createddate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("modifiedbyuserid")]
        public int ModifiedByUserId { get; set; }

        [Required]
        [Column("modifieddate")]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Users User { get; set; } = null!;
        public virtual Companies? Company { get; set; }
        public virtual UserAddresses? UserAddress { get; set; }
        public virtual UserEmployments? UserEmployment { get; set; }
    }
}
