using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CFDatabaseAccessLibrary.Models
{
    // User Management Models
    [Table("feedback_users")]
    public class User
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
        public virtual UserProfile? UserProfile { get; set; }
        public virtual ICollection<Feedback> SubmittedFeedback { get; set; } = new List<Feedback>();
        public virtual ICollection<Feedback> AssignedFeedback { get; set; } = new List<Feedback>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual ICollection<InternalNote> InternalNotes { get; set; } = new List<InternalNote>();
        public virtual ICollection<FeedbackStatusHistory> StatusHistories { get; set; } = new List<FeedbackStatusHistory>();
    }

    [Table("feedback_userprofiles")]
    public class UserProfile
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("userid")]
        public int UserId { get; set; }

        [MaxLength(100)]
        [Column("jobtitle")]
        public string? JobTitle { get; set; }

        [MaxLength(100)]
        [Column("department")]
        public string? Department { get; set; }

        [Column("companyid")]
        public int? CompanyId { get; set; }

        [MaxLength(500)]
        [Column("bio")]
        public string? Bio { get; set; }

        [MaxLength(255)]
        [Column("profileimageurl")]
        public string? ProfileImageUrl { get; set; }

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
        public virtual User User { get; set; } = null!;
        public virtual Company? Company { get; set; }
        public virtual UserAddress? UserAddress { get; set; }
        public virtual UserEmployment? UserEmployment { get; set; }
    }

    [Table("feedback_useraddresses")]
    public class UserAddress
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        [Column("userprofileid")]
        public int UserProfileId { get; set; }

        [MaxLength(255)]
        [Column("streetaddress")]
        public string? StreetAddress { get; set; }

        [MaxLength(100)]
        [Column("city")]
        public string? City { get; set; }

        [MaxLength(100)]
        [Column("stateprovince")]
        public string? StateProvince { get; set; }

        [MaxLength(20)]
        [Column("postalcode")]
        public string? PostalCode { get; set; }

        [MaxLength(100)]
        [Column("country")]
        public string? Country { get; set; }

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
        public virtual UserProfile UserProfile { get; set; } = null!;
    }

    [Table("feedback_useremployments")]
    public class UserEmployment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        [Column("userprofileid")]
        public int UserProfileId { get; set; }

        [MaxLength(100)]
        [Column("position")]
        public string? Position { get; set; }

        [Column("departmentid")]
        public int? DepartmentId { get; set; }

        [Column("startdate")]
        public DateTime? StartDate { get; set; }

        [Column("enddate")]
        public DateTime? EndDate { get; set; }

        [MaxLength(500)]
        [Column("description")]
        public string? Description { get; set; }

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
        public virtual UserProfile UserProfile { get; set; } = null!;
        public virtual Department? Department { get; set; }
    }

    // Role Management Models
    [Table("feedback_roles")]
    public class Role
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("rolename")]
        public string RoleName { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column("description")]
        public string? Description { get; set; }

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
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }

    [Table("feedback_userroles")]
    public class UserRole
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("userid")]
        public int UserId { get; set; }

        [ForeignKey("Role")]
        [Column("roleid")]
        public int RoleId { get; set; }

        [Column("assignedat")]
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("AssignedByUser")]
        [Column("assignedbyuserid")]
        public int? AssignedByUserId { get; set; }

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
        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
        public virtual User? AssignedByUser { get; set; }
    }

    // Company and Organization Models
    [Table("feedback_companies")]
    public class Company
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
        public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
        public virtual ICollection<SystemProject> SystemProjects { get; set; } = new List<SystemProject>();
    }

    [Table("feedback_departments")]
    public class Department
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("departmentname")]
        public string DepartmentName { get; set; } = string.Empty;

        [MaxLength(500)]
        [Column("description")]
        public string? Description { get; set; }

        [ForeignKey("Company")]
        [Column("companyid")]
        public int? CompanyId { get; set; }

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
        public virtual Company? Company { get; set; }
        public virtual ICollection<UserEmployment> UserEmployments { get; set; } = new List<UserEmployment>();
    }

    // System and Project Models
    [Table("feedback_systemprojects")]
    public class SystemProject
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("projectname")]
        public string ProjectName { get; set; } = string.Empty;

        [MaxLength(500)]
        [Column("description")]
        public string? Description { get; set; }

        [ForeignKey("Company")]
        [Column("companyid")]
        public int? CompanyId { get; set; }

        [MaxLength(50)]
        [Column("version")]
        public string? Version { get; set; }

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
        public virtual Company? Company { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; } = new List<Feedback>();
    }

    // Feedback Core Models
    [Table("feedback_categories")]
    public class FeedbackCategory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("categoryname")]
        public string CategoryName { get; set; } = string.Empty;

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
        public virtual ICollection<Feedback> Feedback { get; set; } = new List<Feedback>();
    }

    [Table("feedback_priorities")]
    public class FeedbackPriority
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
        public virtual ICollection<Feedback> Feedback { get; set; } = new List<Feedback>();
    }

    [Table("feedback_statuses")]
    public class FeedbackStatus
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
        public virtual ICollection<Feedback> Feedback { get; set; } = new List<Feedback>();
        public virtual ICollection<FeedbackStatusHistory> StatusHistories { get; set; } = new List<FeedbackStatusHistory>();
    }

    // Main Feedback Model
    [Table("feedback_feedbacks")]
    public class Feedback
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
        public virtual User SubmittedByUser { get; set; } = null!;
        public virtual User? AssignedToUser { get; set; }
        public virtual FeedbackCategory Category { get; set; } = null!;
        public virtual FeedbackPriority Priority { get; set; } = null!;
        public virtual FeedbackStatus FeedbackStatus { get; set; } = null!;
        public virtual SystemProject? SystemProject { get; set; }
        public virtual ICollection<FeedbackStatusHistory> StatusHistory { get; set; } = new List<FeedbackStatusHistory>();
        public virtual ICollection<FeedbackAttachment> Attachments { get; set; } = new List<FeedbackAttachment>();
        public virtual ICollection<InternalNote> InternalNotes { get; set; } = new List<InternalNote>();
    }

    // Supporting Models
    [Table("feedback_statushistory")]
    public class FeedbackStatusHistory
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
        public virtual Feedback Feedback { get; set; } = null!;
        public virtual FeedbackStatus? OldStatus { get; set; }
        public virtual FeedbackStatus NewStatus { get; set; } = null!;
        public virtual User ChangedByUser { get; set; } = null!;
    }

    [Table("feedback_attachments")]
    public class FeedbackAttachment
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
        public virtual Feedback Feedback { get; set; } = null!;
        public virtual User UploadedByUser { get; set; } = null!;
    }

    [Table("feedback_internalnotes")]
    public class InternalNote
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
        public virtual Feedback Feedback { get; set; } = null!;
        public virtual User CreatedByUserNavigation { get; set; } = null!;
    }
}