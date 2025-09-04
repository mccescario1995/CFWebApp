using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_feedbacks")]
    public class Feedbacks
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("SubmittedByUser")]
        [Column("submittedbyuserid")]
        public int SubmittedByUserId { get; set; }

        [ForeignKey("AssignedToUser")]
        [Column("assignedtouserid")]
        public int? AssignedToUserId { get; set; }

        [ForeignKey("Category")]
        [Column("categoryid")]
        public int CategoryId { get; set; }

        [ForeignKey("Priority")]
        [Column("priorityid")]
        public int PriorityId { get; set; }

        [ForeignKey("FeedbackStatus")]
        [Column("statusid")]
        public int StatusId { get; set; }

        [ForeignKey("SystemProject")]
        [Column("systemprojectid")]
        public int? SystemProjectId { get; set; }

        [MaxLength(50)]
        [Column("affectedversion")]
        public string? AffectedVersion { get; set; }

        [Column("submittedat")]
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        [Column("resolvedat")]
        public DateTime? ResolvedAt { get; set; }

        [MaxLength(1000)]
        [Column("resolutionnotes")]
        public string? ResolutionNotes { get; set; }

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
        public virtual Users SubmittedByUser { get; set; } = null!;
        public virtual Users? AssignedToUser { get; set; }
        public virtual FeedbackCategories Category { get; set; } = null!;
        public virtual FeedbackPriorities Priority { get; set; } = null!;
        public virtual FeedbackStatuses FeedbackStatus { get; set; } = null!;
        public virtual SystemProjects? SystemProject { get; set; }
        public virtual ICollection<FeedbackStatusHistories> StatusHistory { get; set; } = new List<FeedbackStatusHistories>();
        public virtual ICollection<FeedbackAttachments> Attachments { get; set; } = new List<FeedbackAttachments>();
        public virtual ICollection<InternalNotes> InternalNotes { get; set; } = new List<InternalNotes>();
    }
}
