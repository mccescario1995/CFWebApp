using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_statuses")]
    public class FeedbackStatuses
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("statusname")]
        public string StatusName { get; set; } = string.Empty;

        [MaxLength(500)]
        [Column("description")]
        public string? Description { get; set; }

        [MaxLength(7)]
        [Column("colorcode")]
        public string? ColorCode { get; set; } // For UI color coding

        [Column("isdefault")]
        public byte IsDefault { get; set; } = 0;

        [Column("isfinalstatus")]
        public byte IsFinalStatus { get; set; } = 0; // Marks if this is a closing status

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
        public virtual ICollection<Feedbacks> Feedback { get; set; } = new List<Feedbacks>();
        public virtual ICollection<FeedbackStatusHistories> StatusHistories { get; set; } = new List<FeedbackStatusHistories>();
    }
}
