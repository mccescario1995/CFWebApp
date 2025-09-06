using CFDatabaseAccessLibrary.DataAccess;
using CFDatabaseAccessLibrary.DTOs;
using CFDatabaseAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CFWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] //Disabled for testing    
    public class FeedbackController : ControllerBase
    {
        private readonly CFContext _context;
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(CFContext context, ILogger<FeedbackController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/feedback - Get all feedback with role-based filtering
        [HttpGet]
        public async Task<IActionResult> GetFeedback(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? status = null,
            [FromQuery] string? category = null,
            [FromQuery] string? priority = null,
            [FromQuery] string? search = null)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _logger.LogWarning(userIdClaim);

                if (!int.TryParse(userIdClaim, out int userId))
                {
                    return Unauthorized(new { message = "Invalid user ID" });
                }

                // Get user's role to determine access level
                var userRole = await GetUserRole(userId);

                var query = _context.Feedbacks
                    .Include(f => f.SubmittedByUser)
                    .Include(f => f.AssignedToUser)
                    .Include(f => f.Category)
                    .Include(f => f.Priority)
                    .Include(f => f.FeedbackStatus)
                    .Include(f => f.SystemProject)
                    .Where(f => f.IsDelete == 0);

                // Role-based filtering
                if (userRole == "Customer")
                {
                    // Customers can only see their own feedback
                    query = query.Where(f => f.SubmittedByUserId == userId);
                }
                else if (userRole == "Support")
                {
                    // Support can see assigned feedback and unassigned feedback
                    query = query.Where(f => f.AssignedToUserId == userId || f.AssignedToUserId == null);
                }
                // Admin can see all feedback (no additional filter)

                // Apply filters
                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(f => f.FeedbackStatus.StatusName.ToLower().Contains(status.ToLower()));
                }

                if (!string.IsNullOrEmpty(category))
                {
                    query = query.Where(f => f.Category.CategoryName.ToLower().Contains(category.ToLower()));
                }

                if (!string.IsNullOrEmpty(priority))
                {
                    query = query.Where(f => f.Priority.PriorityName.ToLower().Contains(priority.ToLower()));
                }

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(f => f.Title.Contains(search) || f.Description.Contains(search));
                }

                // Get total count for pagination
                var totalCount = await query.CountAsync();

                // Apply pagination
                var feedback = await query
                    .OrderByDescending(f => f.CreatedDate)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(f => new FeedbackListDto
                    {
                        Id = f.Id,
                        Title = f.Title,
                        Description = f.Description.Length > 150 ? f.Description.Substring(0, 150) + "..." : f.Description,
                        SubmittedByUser = f.SubmittedByUser.FirstName + " " + f.SubmittedByUser.LastName,
                        AssignedToUser = f.AssignedToUser != null ? f.AssignedToUser.FirstName + " " + f.AssignedToUser.LastName : null,
                        CategoryName = f.Category.CategoryName,
                        PriorityName = f.Priority.PriorityName,
                        StatusName = f.FeedbackStatus.StatusName,
                        StatusColor = f.FeedbackStatus.ColorCode,
                        PriorityLevel = f.Priority.PriorityLevel,
                        SubmittedAt = f.SubmittedAt,
                        ResolvedAt = f.ResolvedAt,
                        SystemProjectName = f.SystemProject != null ? f.SystemProject.ProjectName : null
                    })
                    .ToListAsync();

                var response = new PaginatedResponseDto<FeedbackListDto>
                {
                    Data = feedback,
                    TotalCount = totalCount,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving feedback");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        // GET: api/feedback/{id} - Get feedback details
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _logger.LogWarning(userIdClaim);

                if (!int.TryParse(userIdClaim, out int userId))
                {
                    return Unauthorized(new { message = "Invalid user ID" });
                }

                var feedback = await _context.Feedbacks
                    .Include(f => f.SubmittedByUser)
                    .Include(f => f.AssignedToUser)
                    .Include(f => f.Category)
                    .Include(f => f.Priority)
                    .Include(f => f.FeedbackStatus)
                    .Include(f => f.SystemProject)
                    .Include(f => f.StatusHistory)
                        .ThenInclude(h => h.ChangedByUser)
                    .Include(f => f.StatusHistory)
                        .ThenInclude(h => h.NewStatus)
                    .Include(f => f.StatusHistory)
                        .ThenInclude(h => h.OldStatus)
                    .FirstOrDefaultAsync(f => f.Id == id && f.IsDelete == 0);

                if (feedback == null)
                {
                    return NotFound(new { message = "Feedback not found" });
                }

                // Check access permissions
                var userRole = await GetUserRole(userId);
                if (userRole == "Customer" && feedback.SubmittedByUserId != userId)
                {
                    return Forbid("You can only view your own feedback");
                }

                var feedbackDetail = new FeedbackDetailDto
                {
                    Id = feedback.Id,
                    Title = feedback.Title,
                    Description = feedback.Description,
                    SubmittedByUser = new UserSummaryDto
                    {
                        Id = feedback.SubmittedByUser.Id,
                        Name = feedback.SubmittedByUser.FirstName + " " + feedback.SubmittedByUser.LastName,
                        Email = feedback.SubmittedByUser.Email
                    },
                    AssignedToUser = feedback.AssignedToUser != null ? new UserSummaryDto
                    {
                        Id = feedback.AssignedToUser.Id,
                        Name = feedback.AssignedToUser.FirstName + " " + feedback.AssignedToUser.LastName,
                        Email = feedback.AssignedToUser.Email
                    } : null,
                    Category = new CategoryDto
                    {
                        Id = feedback.Category.Id,
                        Name = feedback.Category.CategoryName,
                        ColorCode = feedback.Category.ColorCode
                    },
                    Priority = new PriorityDto
                    {
                        Id = feedback.Priority.Id,
                        Name = feedback.Priority.PriorityName,
                        Level = feedback.Priority.PriorityLevel,
                        ColorCode = feedback.Priority.ColorCode
                    },
                    Status = new StatusDto
                    {
                        Id = feedback.FeedbackStatus.Id,
                        Name = feedback.FeedbackStatus.StatusName,
                        ColorCode = feedback.FeedbackStatus.ColorCode
                    },
                    SystemProject = feedback.SystemProject != null ? new SystemProjectDto
                    {
                        SystemProjectId = feedback.SystemProject.Id,
                        ProjectName = feedback.SystemProject.ProjectName,
                        Version = feedback.SystemProject.Version
                    } : null,
                    AffectedVersion = feedback.AffectedVersion,
                    SubmittedAt = feedback.SubmittedAt,
                    ResolvedAt = feedback.ResolvedAt,
                    ResolutionNotes = feedback.ResolutionNotes,
                    StatusHistory = feedback.StatusHistory
                        .Where(h => h.IsDelete == 0)
                        .OrderByDescending(h => h.ChangedAt)
                        .Select(h => new StatusHistoryDto
                        {
                            Id = h.Id,
                            OldStatus = h.OldStatus?.StatusName,
                            NewStatus = h.NewStatus.StatusName,
                            ChangedBy = h.ChangedByUser.FirstName + " " + h.ChangedByUser.LastName,
                            ChangeReason = h.ChangeReason,
                            Notes = h.Notes,
                            ChangedAt = h.ChangedAt
                        }).ToList()
                };

                return Ok(feedbackDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving feedback {FeedbackId}", id);
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        // POST: api/feedback - Create new feedback (customer submission)
        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackDto createFeedbackDto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _logger.LogWarning(userIdClaim);

                if (!int.TryParse(userIdClaim, out int userId))
                {
                    return Unauthorized(new { message = "Invalid user ID" });
                }

                // Validate required entities exist
                var categoryExists = await _context.FeedbackCategories.AnyAsync(c => c.Id == createFeedbackDto.CategoryId && c.IsDelete == 0);
                if (!categoryExists)
                {
                    return BadRequest(new { message = "Invalid category ID" });
                }

                var priorityExists = await _context.FeedbackPriorities.AnyAsync(p => p.Id == createFeedbackDto.PriorityId && p.IsDelete == 0);
                if (!priorityExists)
                {
                    return BadRequest(new { message = "Invalid priority ID" });
                }

                // Get default status (typically "Open" or "New")
                var defaultStatus = await _context.FeedbackStatuses
                    .FirstOrDefaultAsync(s => s.IsDefault == 1 && s.IsDelete == 0);

                if (defaultStatus == null)
                {
                    return BadRequest(new { message = "No default status configured" });
                }

                var feedback = new Feedbacks
                {
                    Title = createFeedbackDto.Title,
                    Description = createFeedbackDto.Description,
                    SubmittedByUserId = userId,
                    CategoryId = createFeedbackDto.CategoryId,
                    PriorityId = createFeedbackDto.PriorityId,
                    StatusId = defaultStatus.Id,
                    SystemProjectId = createFeedbackDto.SystemProjectId,
                    AffectedVersion = createFeedbackDto.AffectedVersion,
                    SubmittedAt = DateTime.UtcNow,
                    CreatedByUserId = userId,
                    ModifiedByUserId = userId
                };

                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                // Create initial status history
                var statusHistory = new FeedbackStatusHistories
                {
                    FeedbackId = feedback.Id,
                    NewStatusId = defaultStatus.Id,
                    ChangedByUserId = userId,
                    ChangeReason = "Initial submission",
                    CreatedByUserId = userId,
                    ModifiedByUserId = userId
                };

                _context.FeedbackStatusHistories.Add(statusHistory);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, new { id = feedback.Id, message = "Feedback created successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating feedback");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        // PUT: api/feedback/{id}/status - Update feedback status (support/admin only)
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateFeedbackStatus(int id, [FromBody] UpdateStatusDto updateStatusDto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _logger.LogWarning(userIdClaim);

                if (!int.TryParse(userIdClaim, out int userId))
                {
                    return Unauthorized(new { message = "Invalid user ID" });
                }

                // Check if user has permission (Support or Admin)
                var userRole = await GetUserRole(userId);
                if (userRole == "Customer")
                {
                    return Forbid("Customers cannot update feedback status");
                }

                var feedback = await _context.Feedbacks
                    .Include(f => f.FeedbackStatus)
                    .FirstOrDefaultAsync(f => f.Id == id && f.IsDelete == 0);

                if (feedback == null)
                {
                    return NotFound(new { message = "Feedback not found" });
                }

                var newStatus = await _context.FeedbackStatuses
                    .FirstOrDefaultAsync(s => s.Id == updateStatusDto.StatusId && s.IsDelete == 0);

                if (newStatus == null)
                {
                    return BadRequest(new { message = "Invalid status ID" });
                }

                var oldStatusId = feedback.StatusId;
                feedback.StatusId = updateStatusDto.StatusId;
                feedback.ModifiedByUserId = userId;
                feedback.ModifiedDate = DateTime.UtcNow;

                // If status is marked as final, set resolved date
                if (newStatus.IsFinalStatus == 1 && feedback.ResolvedAt == null)
                {
                    feedback.ResolvedAt = DateTime.UtcNow;
                }

                // Add resolution notes if provided
                if (!string.IsNullOrEmpty(updateStatusDto.ResolutionNotes))
                {
                    feedback.ResolutionNotes = updateStatusDto.ResolutionNotes;
                }

                // Create status history entry
                var statusHistory = new FeedbackStatusHistories
                {
                    FeedbackId = feedback.Id,
                    OldStatusId = oldStatusId,
                    NewStatusId = updateStatusDto.StatusId,
                    ChangedByUserId = userId,
                    ChangeReason = updateStatusDto.ChangeReason,
                    Notes = updateStatusDto.Notes,
                    CreatedByUserId = userId,
                    ModifiedByUserId = userId
                };

                _context.FeedbackStatusHistories.Add(statusHistory);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Feedback status updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating feedback status {FeedbackId}", id);
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        // PUT: api/feedback/{id}/assign - Assign feedback to user (support/admin only)
        [HttpPut("{id}/assign")]
        public async Task<IActionResult> AssignFeedback(int id, [FromBody] AssignFeedbackDto assignFeedbackDto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _logger.LogWarning(userIdClaim);

                if (!int.TryParse(userIdClaim, out int userId))
                {
                    return Unauthorized(new { message = "Invalid user ID" });
                }

                // Check if user has permission (Support or Admin)
                var userRole = await GetUserRole(userId);
                if (userRole == "Customer")
                {
                    return Forbid("Customers cannot assign feedback");
                }

                var feedback = await _context.Feedbacks
                    .FirstOrDefaultAsync(f => f.Id == id && f.IsDelete == 0);

                if (feedback == null)
                {
                    return NotFound(new { message = "Feedback not found" });
                }

                // Validate assignee exists and has appropriate role
                var assigneeExists = await _context.Users
                    .Join(_context.UserRoles, u => u.Id, ur => ur.UserId,
                          (u, ur) => new { User = u, UserRole = ur })
                    .Join(_context.Roles, ur => ur.UserRole.RoleId, r => r.Id,
                          (ur, r) => new { ur.User, Role = r })
                    .AnyAsync(x => x.User.Id == assignFeedbackDto.AssignedToUserId &&
                                   x.User.IsDelete == 0 &&
                                   (x.Role.RoleName == "Support" || x.Role.RoleName == "Admin"));

                if (!assigneeExists)
                {
                    return BadRequest(new { message = "Invalid assignee or assignee does not have support permissions" });
                }

                feedback.AssignedToUserId = assignFeedbackDto.AssignedToUserId;
                feedback.ModifiedByUserId = userId;
                feedback.ModifiedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Feedback assigned successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning feedback {FeedbackId}", id);
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        // GET: api/feedback/queue - Get unassigned feedback (support/admin only)
        [HttpGet("queue")]
        public async Task<IActionResult> GetFeedbackQueue(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? priority = null,
            [FromQuery] string? category = null)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _logger.LogWarning(userIdClaim);

                if (!int.TryParse(userIdClaim, out int userId))
                {
                    return Unauthorized(new { message = "Invalid user ID" });
                }

                // Check if user has permission (Support or Admin)
                var userRole = await GetUserRole(userId);
                if (userRole == "Customer")
                {
                    return Forbid("Customers cannot access feedback queue");
                }

                var query = _context.Feedbacks
                    .Include(f => f.SubmittedByUser)
                    .Include(f => f.Category)
                    .Include(f => f.Priority)
                    .Include(f => f.FeedbackStatus)
                    .Include(f => f.SystemProject)
                    .Where(f => f.IsDelete == 0 && f.AssignedToUserId == null);

                // Apply filters
                if (!string.IsNullOrEmpty(priority))
                {
                    query = query.Where(f => f.Priority.PriorityName.ToLower().Contains(priority.ToLower()));
                }

                if (!string.IsNullOrEmpty(category))
                {
                    query = query.Where(f => f.Category.CategoryName.ToLower().Contains(category.ToLower()));
                }

                var totalCount = await query.CountAsync();

                var feedbackQueue = await query
                    .OrderBy(f => f.Priority.PriorityLevel) // Higher priority first (lower number)
                    .ThenByDescending(f => f.SubmittedAt) // Then by submission date
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(f => new FeedbackListDto
                    {
                        Id = f.Id,
                        Title = f.Title,
                        Description = f.Description.Length > 150 ? f.Description.Substring(0, 150) + "..." : f.Description,
                        SubmittedByUser = f.SubmittedByUser.FirstName + " " + f.SubmittedByUser.LastName,
                        CategoryName = f.Category.CategoryName,
                        PriorityName = f.Priority.PriorityName,
                        StatusName = f.FeedbackStatus.StatusName,
                        StatusColor = f.FeedbackStatus.ColorCode,
                        PriorityLevel = f.Priority.PriorityLevel,
                        SubmittedAt = f.SubmittedAt,
                        SystemProjectName = f.SystemProject != null ? f.SystemProject.ProjectName : null
                    })
                    .ToListAsync();

                var response = new PaginatedResponseDto<FeedbackListDto>
                {
                    Data = feedbackQueue,
                    TotalCount = totalCount,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving feedback queue");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        // GET: api/feedback/assigned/{userId} - Get feedback assigned to specific user
        [HttpGet("assigned/{userId}")]
        public async Task<IActionResult> GetAssignedFeedback(int userId,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var currentUserIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _logger.LogWarning(currentUserIdClaim);

                if (!int.TryParse(currentUserIdClaim, out int currentUserId))
                {
                    return Unauthorized(new { message = "Invalid user ID" });
                }

                // Check permissions - users can only see their own assigned feedback unless they're admin
                var userRole = await GetUserRole(currentUserId);
                if (userRole != "Admin" && currentUserId != userId)
                {
                    return Forbid("You can only view your own assigned feedback");
                }

                var query = _context.Feedbacks
                    .Include(f => f.SubmittedByUser)
                    .Include(f => f.Category)
                    .Include(f => f.Priority)
                    .Include(f => f.FeedbackStatus)
                    .Include(f => f.SystemProject)
                    .Where(f => f.IsDelete == 0 && f.AssignedToUserId == userId);

                var totalCount = await query.CountAsync();

                var assignedFeedback = await query
                    .OrderBy(f => f.Priority.PriorityLevel)
                    .ThenByDescending(f => f.SubmittedAt)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(f => new FeedbackListDto
                    {
                        Id = f.Id,
                        Title = f.Title,
                        Description = f.Description.Length > 150 ? f.Description.Substring(0, 150) + "..." : f.Description,
                        SubmittedByUser = f.SubmittedByUser.FirstName + " " + f.SubmittedByUser.LastName,
                        CategoryName = f.Category.CategoryName,
                        PriorityName = f.Priority.PriorityName,
                        StatusName = f.FeedbackStatus.StatusName,
                        StatusColor = f.FeedbackStatus.ColorCode,
                        PriorityLevel = f.Priority.PriorityLevel,
                        SubmittedAt = f.SubmittedAt,
                        SystemProjectName = f.SystemProject != null ? f.SystemProject.ProjectName : null
                    })
                    .ToListAsync();

                var response = new PaginatedResponseDto<FeedbackListDto>
                {
                    Data = assignedFeedback,
                    TotalCount = totalCount,
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving assigned feedback for user {UserId}", userId);
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        // GET: api/feedback/metadata - Get categories, priorities, statuses for form dropdowns
        [HttpGet("metadata")]
        public async Task<IActionResult> GetFeedbackMetadata()
        {
            try
            {
                var categories = await _context.FeedbackCategories
                    .Where(c => c.IsDelete == 0 && c.Status == 1)
                    .Select(c => new { value = c.Id, label = c.CategoryName, color = c.ColorCode })
                    .OrderBy(c => c.label)
                    .ToListAsync();

                var priorities = await _context.FeedbackPriorities
                    .Where(p => p.IsDelete == 0 && p.Status == 1)
                    .Select(p => new { value = p.Id, label = p.PriorityName, level = p.PriorityLevel, color = p.ColorCode })
                    .OrderBy(p => p.level)
                    .ToListAsync();

                var statuses = await _context.FeedbackStatuses
                    .Where(s => s.IsDelete == 0 && s.Status == 1)
                    .Select(s => new { value = s.Id, label = s.StatusName, color = s.ColorCode, isDefault = s.IsDefault == 1, isFinal = s.IsFinalStatus == 1 })
                    .OrderBy(s => s.label)
                    .ToListAsync();

                var projects = await _context.SystemProjects
                    .Where(p => p.IsDelete == 0 && p.Status == 1)
                    .Select(p => new { value = p.Id, label = p.ProjectName, version = p.Version })
                    .OrderBy(p => p.label)
                    .ToListAsync();

                return Ok(new
                {
                    categories,
                    priorities,
                    statuses,
                    projects
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving feedback metadata");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        // Helper method to get user role
        private async Task<string> GetUserRole(int userId)
        {
            var userRole = await _context.UserRoles
                .Include(ur => ur.Role)
                .Where(ur => ur.UserId == userId && ur.IsDelete == 0)
                .Select(ur => ur.Role.RoleName)
                .FirstOrDefaultAsync();

            return userRole ?? "Customer"; // Default to Customer if no role found
        }
    }
}