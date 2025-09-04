using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_useremployments")]
    public class UserEmployments
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        [Column("userprofileid")]
        public int UserProfileId { get; set; }

        [MaxLength(100)]
        [Column("position")]
        public string? Position { get; set; }

        [Column("departmentid")]
        public int? DepartmentId { get; set; }

        [Column("startdate")]
        public DateTime? StartDate { get; set; }

        [Column("enddate")]
        public DateTime? EndDate { get; set; }

        [MaxLength(500)]
        [Column("description")]
        public string? Description { get; set; }

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
        public virtual UserProfiles UserProfile { get; set; } = null!;
        public virtual Departments? Department { get; set; }
    }
}
