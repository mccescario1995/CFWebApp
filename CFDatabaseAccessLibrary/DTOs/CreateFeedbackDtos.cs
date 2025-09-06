using System.ComponentModel.DataAnnotations;

namespace CFDatabaseAccessLibrary.DTOs
{
    // Request DTOs for creating and updating feedback
    //public class CreateFeedbackDto
    //{
    //    [Required]
    //    [MaxLength(255)]
    //    public string Title { get; set; } = string.Empty;

    //    [Required]
    //    public string Description { get; set; } = string.Empty;

    //    [Required]
    //    public int CategoryId { get; set; }

    //    [Required]
    //    public int PriorityId { get; set; }

    //    public int? SystemProjectId { get; set; }

    //    [MaxLength(50)]
    //    public string? AffectedVersion { get; set; }
    //}

    public class UpdateStatusDto
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

    //public class AssignFeedbackDto
    //{
    //    [Required]
    //    public int AssignedToUserId { get; set; }
    //}

    // Response DTOs for returning feedback data
    public class FeedbackListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SubmittedByUser { get; set; } = string.Empty;
        public string? AssignedToUser { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string PriorityName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public string? StatusColor { get; set; }
        public int PriorityLevel { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string? SystemProjectName { get; set; }
    }

    public class FeedbackDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public UserSummaryDto SubmittedByUser { get; set; } = null!;
        public UserSummaryDto? AssignedToUser { get; set; }
        public CategoryDto Category { get; set; } = null!;
        public PriorityDto Priority { get; set; } = null!;
        public StatusDto Status { get; set; } = null!;
        public SystemProjectDto? SystemProject { get; set; }
        public string? AffectedVersion { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string? ResolutionNotes { get; set; }
        public List<StatusHistoryDto> StatusHistory { get; set; } = new List<StatusHistoryDto>();
    }

    // Supporting DTOs
    public class UserSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ColorCode { get; set; }
    }

    public class PriorityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public string? ColorCode { get; set; }
    }

    public class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ColorCode { get; set; }
    }


    public class StatusHistoryDto
    {
        public int Id { get; set; }
        public string? OldStatus { get; set; }
        public string NewStatus { get; set; } = string.Empty;
        public string ChangedBy { get; set; } = string.Empty;
        public string? ChangeReason { get; set; }
        public string? Notes { get; set; }
        public DateTime ChangedAt { get; set; }
    }

    // Generic pagination response DTO
    public class PaginatedResponseDto<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}