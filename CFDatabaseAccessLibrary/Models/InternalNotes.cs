using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_internalnotes")]
    public class InternalNotes
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Feedback")]
        [Column("feedbackid")]
        public int FeedbackId { get; set; }

        [ForeignKey("CreatedByUser")]
        [Column("createdbyuser")]
        public int CreatedByUser { get; set; }

        [Required]
        [Column("notecontent")]
        public string NoteContent { get; set; } = string.Empty;

        [Column("isvisible")]
        public byte IsVisible { get; set; } = 1; // For soft delete

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
        public virtual Users CreatedByUserNavigation { get; set; } = null!;
    }
}
