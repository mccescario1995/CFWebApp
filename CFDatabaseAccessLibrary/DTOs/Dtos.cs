using System.ComponentModel.DataAnnotations;

namespace CFDatabaseAccessLibrary.DTOs
{
    // Authentication DTOs
    public class    LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        public int? CompanyId { get; set; }

        [MaxLength(100)]
        public string? JobTitle { get; set; }

        [MaxLength(100)]
        public string? Department { get; set; }
    }

    public class AuthResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Token { get; set; }
        public UserDto? User { get; set; }
    }

    // User DTOs
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public UserProfileDto? UserProfile { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }

    public class UserProfileDto
    {
        public int UserProfileId { get; set; }
        public int UserId { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public UserAddressDto? UserAddress { get; set; }
        public UserEmploymentDto? UserEmployment { get; set; }
    }

    public class UserAddressDto
    {
        public int UserAddressId { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? StateProvince { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }

    public class UserEmploymentDto
    {
        public int UserEmploymentId { get; set; }
        public string? Position { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateUserProfileDto
    {
        [MaxLength(100)]
        public string? JobTitle { get; set; }

        [MaxLength(100)]
        public string? Department { get; set; }

        public int? CompanyId { get; set; }

        [MaxLength(500)]
        public string? Bio { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        public UserAddressUpdateDto? UserAddress { get; set; }
        public UserEmploymentUpdateDto? UserEmployment { get; set; }
    }

    public class UserAddressUpdateDto
    {
        [MaxLength(255)]
        public string? StreetAddress { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? StateProvince { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }
    }

    public class UserEmploymentUpdateDto
    {
        [MaxLength(100)]
        public string? Position { get; set; }

        public int? DepartmentId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }

    // Feedback DTOs
    public class FeedbackDto
    {
        public int FeedbackId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SubmittedByUserId { get; set; }
        public string SubmittedByUserName { get; set; } = string.Empty;
        public int? AssignedToUserId { get; set; }
        public string? AssignedToUserName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? CategoryColor { get; set; }
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
        public int PriorityLevel { get; set; }
        public string? PriorityColor { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string? StatusColor { get; set; }
        public int? SystemProjectId { get; set; }
        public string? SystemProjectName { get; set; }
        public string? AffectedVersion { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string? ResolutionNotes { get; set; }
        public List<FeedbackAttachmentDto> Attachments { get; set; } = new List<FeedbackAttachmentDto>();
        public List<FeedbackStatusHistoryDto> StatusHistory { get; set; } = new List<FeedbackStatusHistoryDto>();
    }

    public class CreateFeedbackDto
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int PriorityId { get; set; }

        public int? SystemProjectId { get; set; }

        [MaxLength(50)]
        public string? AffectedVersion { get; set; }
    }

    public class UpdateFeedbackDto
    {
        [MaxLength(255)]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public int? PriorityId { get; set; }

        public int? SystemProjectId { get; set; }

        [MaxLength(50)]
        public string? AffectedVersion { get; set; }
    }

    public class UpdateFeedbackStatusDto
    {
        [Required]
        public int StatusId { get; set; }

        [MaxLength(500)]
        public string? ChangeReason { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }

        [MaxLength(1000)]
        public string? ResolutionNotes { get; set; }
    }

    public class AssignFeedbackDto
    {
        public int? AssignedToUserId { get; set; }

        [MaxLength(500)]
        public string? AssignmentReason { get; set; }
    }

    // Supporting DTOs
    public class FeedbackCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ColorCode { get; set; }
        public bool IsActive { get; set; }
    }

    public class FeedbackPriorityDto
    {
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
        public int PriorityLevel { get; set; }
        public string? Description { get; set; }
        public string? ColorCode { get; set; }
        public bool IsActive { get; set; }
    }

    public class FeedbackStatusDto
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ColorCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public bool IsFinalStatus { get; set; }
    }

    public class FeedbackStatusHistoryDto
    {
        public int StatusHistoryId { get; set; }
        public int FeedbackId { get; set; }
        public int? OldStatusId { get; set; }
        public string? OldStatusName { get; set; }
        public int NewStatusId { get; set; }
        public string NewStatusName { get; set; } = string.Empty;
        public int ChangedByUserId { get; set; }
        public string ChangedByUserName { get; set; } = string.Empty;
        public string? ChangeReason { get; set; }
        public string? Notes { get; set; }
        public DateTime ChangedAt { get; set; }
    }

    public class FeedbackAttachmentDto
    {
        public int AttachmentId { get; set; }
        public int FeedbackId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string? MimeType { get; set; }
        public long FileSize { get; set; }
        public int UploadedByUserId { get; set; }
        public string UploadedByUserName { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
    }

    public class InternalNoteDto
    {
        public int InternalNoteId { get; set; }
        public int FeedbackId { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
        public string NoteContent { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateInternalNoteDto
    {
        [Required]
        public string NoteContent { get; set; } = string.Empty;
    }

    // Company and System DTOs
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Website { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateCompanyDto
    {
        [Required]
        [MaxLength(255)]
        public string CompanyName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(255)]
        public string? Website { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string? Email { get; set; }
    }

    public class SystemProjectDto
    {
        public int SystemProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Version { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateSystemProjectDto
    {
        [Required]
        [MaxLength(255)]
        public string ProjectName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public int? CompanyId { get; set; }

        [MaxLength(50)]
        public string? Version { get; set; }
    }

    // Analytics and Dashboard DTOs
    public class DashboardStatsDto
    {
        public int TotalFeedback { get; set; }
        public int OpenFeedback { get; set; }
        public int InProgressFeedback { get; set; }
        public int ResolvedFeedback { get; set; }
        public int AssignedToMe { get; set; }
        public double AverageResponseTime { get; set; }
        public List<CategoryStatsDto> CategoryStats { get; set; } = new List<CategoryStatsDto>();
        public List<PriorityStatsDto> PriorityStats { get; set; } = new List<PriorityStatsDto>();
        public List<RecentActivityDto> RecentActivity { get; set; } = new List<RecentActivityDto>();
    }

    public class CategoryStatsDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int Count { get; set; }
        public string? ColorCode { get; set; }
    }

    public class PriorityStatsDto
    {
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
        public int Count { get; set; }
        public string? ColorCode { get; set; }
    }

    public class RecentActivityDto
    {
        public int FeedbackId { get; set; }
        public string FeedbackTitle { get; set; } = string.Empty;
        public string ActionType { get; set; } = string.Empty;
        public string ActionDescription { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; }
    }

    // Filtering and Pagination DTOs
    public class FeedbackFilterDto
    {
        public int? StatusId { get; set; }
        public int? CategoryId { get; set; }
        public int? PriorityId { get; set; }
        public int? AssignedToUserId { get; set; }
        public int? SubmittedByUserId { get; set; }
        public int? SystemProjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? SearchTerm { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; } = "SubmittedAt";
        public string? SortDirection { get; set; } = "desc";
    }

    public class PagedResultDto<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }

    // Common Response DTOs
    public class ApiResponseDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class ApiResponseDto : ApiResponseDto<object>
    {
    }
}