using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_attachments")]
    public class FeedbackAttachments
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Feedback")]
        [Column("feedbackid")]
        public int FeedbackId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("filename")]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        [Column("filepath")]
        public string FilePath { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("mimetype")]
        public string? MimeType { get; set; }

        [Column("filesize")]
        public long FileSize { get; set; }

        [ForeignKey("UploadedByUser")]
        [Column("uploadedbyuserid")]
        public int UploadedByUserId { get; set; }

        [Column("uploadedat")]
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

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
        public virtual Users UploadedByUser { get; set; } = null!;
    }
}
