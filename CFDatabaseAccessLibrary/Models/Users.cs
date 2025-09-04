using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_users")]
    public class Users
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("firstname")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("lastname")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("passwordhash")]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(15)]
        [Column("phonenumber")]
        public string? PhoneNumber { get; set; }

        [Column("lastloginat")]
        public DateTime? LastLoginAt { get; set; }

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
        public virtual UserProfiles? UserProfile { get; set; }
        public virtual ICollection<Feedbacks> SubmittedFeedback { get; set; } = new List<Feedbacks>();
        public virtual ICollection<Feedbacks> AssignedFeedback { get; set; } = new List<Feedbacks>();
        public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
        public virtual ICollection<InternalNotes> InternalNotes { get; set; } = new List<InternalNotes>();
        public virtual ICollection<FeedbackStatusHistories> StatusHistories { get; set; } = new List<FeedbackStatusHistories>();

    }
}
