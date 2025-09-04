using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_companies")]
    public class Companies
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("companyname")]
        public string CompanyName { get; set; } = string.Empty;

        [MaxLength(500)]
        [Column("description")]
        public string? Description { get; set; }

        [MaxLength(255)]
        [Column("website")]
        public string? Website { get; set; }

        [MaxLength(15)]
        [Column("phonenumber")]
        public string? PhoneNumber { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        [Column("email")]
        public string? Email { get; set; }

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
        public virtual ICollection<UserProfiles> UserProfiles { get; set; } = new List<UserProfiles>();
        public virtual ICollection<Departments> Departments { get; set; } = new List<Departments>();
        public virtual ICollection<SystemProjects> SystemProjects { get; set; } = new List<SystemProjects>();
    }
}
