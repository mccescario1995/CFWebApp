using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_statushistories")]
    public class FeedbackStatusHistories
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Feedback")]
        [Column("feedbackid")]
        public int FeedbackId { get; set; }

        [ForeignKey("OldStatus")]
        [Column("oldstatusid")]
        public int? OldStatusId { get; set; }

        [ForeignKey("NewStatus")]
        [Column("newstatusid")]
        public int NewStatusId { get; set; }

        [ForeignKey("ChangedByUser")]
        [Column("changedbyuserid")]
        public int ChangedByUserId { get; set; }

        [MaxLength(500)]
        [Column("changereason")]
        public string? ChangeReason { get; set; }

        [MaxLength(1000)]
        [Column("notes")]
        public string? Notes { get; set; }

        [Column("changedat")]
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

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
        public virtual Feedbacks Feedback { get; set; } = null!;
        public virtual FeedbackStatuses? OldStatus { get; set; }
        public virtual FeedbackStatuses NewStatus { get; set; } = null!;
        public virtual Users ChangedByUser { get; set; } = null!;
    }
}
