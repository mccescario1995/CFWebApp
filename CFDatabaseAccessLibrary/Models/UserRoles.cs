using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_userroles")]
    public class UserRoles
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("userid")]
        public int UserId { get; set; }

        [ForeignKey("Role")]
        [Column("roleid")]
        public int RoleId { get; set; }

        [Column("assignedat")]
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("AssignedByUser")]
        [Column("assignedbyuserid")]
        public int? AssignedByUserId { get; set; }

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
        public virtual Roles Role { get; set; } = null!;
        public virtual Users? AssignedByUser { get; set; }
    }
}
