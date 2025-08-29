using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_feedbackcomments")]
    public class FeedbackComments
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("feedbackid")]
        public int FeedbackId { get; set; }

        [Required]
        [Column("userid")]
        public int UserId { get; set; }

        [Required]
        [Column("comment", TypeName = "varchar(1000)")]
        public string Comment { get; set; }

        [Column("isinternal")]
        public byte IsInternal { get; set; } = 0; // Internal notes vs customer-visible comments

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

        public virtual Feedbacks Feedback { get; set; }
        public virtual Users User { get; set; }
    }
}
