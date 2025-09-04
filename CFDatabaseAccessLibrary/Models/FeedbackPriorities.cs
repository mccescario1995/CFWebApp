using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_priorities")]
    public class FeedbackPriorities
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("priorityname")]
        public string PriorityName { get; set; } = string.Empty;

        [Required]
        [Column("prioritylevel")]
        public int PriorityLevel { get; set; } // 1 = Highest, 5 = Lowest

        [MaxLength(500)]
        [Column("description")]
        public string? Description { get; set; }

        [MaxLength(7)]
        [Column("colorcode")]
        public string? ColorCode { get; set; } // For UI color coding

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
    }
}
