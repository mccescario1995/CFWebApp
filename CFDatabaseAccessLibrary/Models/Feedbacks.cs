using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_feedbacks")]
    public class Feedbacks
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("customerid")]
        public int CustomerId { get; set; }

        [Required]
        [Column("subject", TypeName = "varchar(200)")]
        public string Subject { get; set; }

        [Required]
        [Column("description", TypeName = "varchar(2000)")]
        public string Description { get; set; }

        [Required]
        [Column("priority", TypeName = "varchar(20)")]
        public string Priority { get; set; } = "Medium"; // Low, Medium, High, Critical

        [Required]
        [Column("feedbackstatus", TypeName = "varchar(20)")]
        public string FeedbackStatus { get; set; } = "Open"; // Open, InProgress, Resolved, Closed

        [Column("category", TypeName = "varchar(100)")]
        public string Category { get; set; }

        [Column("assignedtouserid")]
        public int? AssignedToUserId { get; set; }

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

        public virtual Users Customer { get; set; }
        public virtual Users AssignedToUser { get; set; }
        public virtual ICollection<FeedbackComments> FeedbackComments { get; set; }
    }
}
