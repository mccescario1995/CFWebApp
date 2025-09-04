using CFDatabaseAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CFDatabaseAccessLibrary.DataAccess
{
    public class CFContext : DbContext
    {
        public CFContext(DbContextOptions<CFContext> options) : base(options)
        {
        }

        // User Management DbSets
        public DbSet<Users> Users { get; set; }
        public DbSet<UserProfiles> UserProfiles { get; set; }
        public DbSet<UserAddresses> UserAddresses { get; set; }
        public DbSet<UserEmployments> UserEmployments { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        // Company and Organization DbSets
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<SystemProjects> SystemProjects { get; set; }

        // Feedback DbSets
        public DbSet<FeedbackCategories> FeedbackCategories { get; set; }
        public DbSet<FeedbackPriorities> FeedbackPriorities { get; set; }
        public DbSet<FeedbackStatuses> FeedbackStatuses { get; set; }
        public DbSet<Feedbacks> Feedbacks { get; set; }
        public DbSet<FeedbackStatusHistories> FeedbackStatusHistories { get; set; }
        public DbSet<FeedbackAttachments> FeedbackAttachments { get; set; }
        public DbSet<InternalNotes> InternalNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            ConfigureUserRelationships(modelBuilder);
            ConfigureFeedbackRelationships(modelBuilder);
            ConfigureIndexes(modelBuilder);
            SeedDefaultData(modelBuilder);
        }

        private void ConfigureUserRelationships(ModelBuilder modelBuilder)
        {
            // User -> UserProfile (One-to-One)
            modelBuilder.Entity<Users>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfiles>(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserProfile -> UserAddress (One-to-One)
            modelBuilder.Entity<UserProfiles>()
                .HasOne(up => up.UserAddress)
                .WithOne(ua => ua.UserProfile)
                .HasForeignKey<UserAddresses>(ua => ua.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserProfile -> UserEmployment (One-to-One)
            modelBuilder.Entity<UserProfiles>()
                .HasOne(up => up.UserEmployment)
                .WithOne(ue => ue.UserProfile)
                .HasForeignKey<UserEmployments>(ue => ue.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserRole relationships
            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.AssignedByUser)
                .WithMany()
                .HasForeignKey(ur => ur.AssignedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Company relationships
            modelBuilder.Entity<Companies>()
                .HasMany(c => c.Departments)
                .WithOne(d => d.Company)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Companies>()
                .HasMany(c => c.SystemProjects)
                .WithOne(sp => sp.Company)
                .HasForeignKey(sp => sp.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        private void ConfigureFeedbackRelationships(ModelBuilder modelBuilder)
        {
            // Feedback -> User relationships
            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.SubmittedByUser)
                .WithMany(u => u.SubmittedFeedback)
                .HasForeignKey(f => f.SubmittedByUserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting users with feedback

            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.AssignedToUser)
                .WithMany(u => u.AssignedFeedback)
                .HasForeignKey(f => f.AssignedToUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Feedback -> Category, Priority, Status
            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.Category)
                .WithMany(fc => fc.Feedback)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.Priority)
                .WithMany(fp => fp.Feedback)
                .HasForeignKey(f => f.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.FeedbackStatus)
                .WithMany(fs => fs.Feedback)
                .HasForeignKey(f => f.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Feedback -> SystemProject
            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.SystemProject)
                .WithMany(sp => sp.Feedback)
                .HasForeignKey(f => f.SystemProjectId)
                .OnDelete(DeleteBehavior.SetNull);

            // FeedbackStatusHistory relationships
            modelBuilder.Entity<FeedbackStatusHistories>()
                .HasOne(fsh => fsh.Feedback)
                .WithMany(f => f.StatusHistory)
                .HasForeignKey(fsh => fsh.FeedbackId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FeedbackStatusHistories>()
                .HasOne(fsh => fsh.OldStatus)
                .WithMany()
                .HasForeignKey(fsh => fsh.OldStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FeedbackStatusHistories>()
                .HasOne(fsh => fsh.NewStatus)
                .WithMany(fs => fs.StatusHistories)
                .HasForeignKey(fsh => fsh.NewStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FeedbackStatusHistories>()
                .HasOne(fsh => fsh.ChangedByUser)
                .WithMany(u => u.StatusHistories)
                .HasForeignKey(fsh => fsh.ChangedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // FeedbackAttachment relationships
            modelBuilder.Entity<FeedbackAttachments>()
                .HasOne(fa => fa.Feedback)
                .WithMany(f => f.Attachments)
                .HasForeignKey(fa => fa.FeedbackId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FeedbackAttachments>()
                .HasOne(fa => fa.UploadedByUser)
                .WithMany()
                .HasForeignKey(fa => fa.UploadedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // InternalNote relationships
            modelBuilder.Entity<InternalNotes>()
                .HasOne(in_ => in_.Feedback)
                .WithMany(f => f.InternalNotes)
                .HasForeignKey(in_ => in_.FeedbackId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InternalNotes>()
                .HasOne(in_ => in_.CreatedByUserNavigation)
                .WithMany(u => u.InternalNotes)
                .HasForeignKey(in_ => in_.CreatedByUser)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureIndexes(ModelBuilder modelBuilder)
        {
            // User indexes
            modelBuilder.Entity<Users>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Users>()
                .HasIndex(u => new { u.Status, u.IsDelete, u.CreatedDate });

            // Feedback indexes for performance
            modelBuilder.Entity<Feedbacks>()
                .HasIndex(f => new { f.StatusId, f.SubmittedAt });

            modelBuilder.Entity<Feedbacks>()
                .HasIndex(f => new { f.AssignedToUserId, f.StatusId });

            modelBuilder.Entity<Feedbacks>()
                .HasIndex(f => new { f.SubmittedByUserId, f.SubmittedAt });

            modelBuilder.Entity<Feedbacks>()
                .HasIndex(f => new { f.CategoryId, f.PriorityId });

            modelBuilder.Entity<Feedbacks>()
                .HasIndex(f => new { f.Status, f.IsDelete });

            // FeedbackStatusHistory indexes
            modelBuilder.Entity<FeedbackStatusHistories>()
                .HasIndex(fsh => new { fsh.FeedbackId, fsh.ChangedAt });

            // Role and UserRole indexes
            modelBuilder.Entity<Roles>()
                .HasIndex(r => r.RoleName)
                .IsUnique();

            modelBuilder.Entity<UserRoles>()
                .HasIndex(ur => new { ur.UserId, ur.RoleId })
                .IsUnique();

            // Global status/isdelete indexes for all entities
            modelBuilder.Entity<UserProfiles>()
                .HasIndex(up => new { up.Status, up.IsDelete });

            modelBuilder.Entity<Companies>()
                .HasIndex(c => new { c.Status, c.IsDelete });

            modelBuilder.Entity<Departments>()
                .HasIndex(d => new { d.Status, d.IsDelete });

            modelBuilder.Entity<SystemProjects>()
                .HasIndex(sp => new { sp.Status, sp.IsDelete });

            modelBuilder.Entity<FeedbackCategories>()
                .HasIndex(fc => new { fc.Status, fc.IsDelete });

            modelBuilder.Entity<FeedbackPriorities>()
                .HasIndex(fp => new { fp.Status, fp.IsDelete });

            modelBuilder.Entity<FeedbackStatuses>()
                .HasIndex(fs => new { fs.Status, fs.IsDelete });
        }

        private void SeedDefaultData(ModelBuilder modelBuilder)
        {
            var defaultDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Seed default roles
            modelBuilder.Entity<Roles>().HasData(
                new Roles
                {
                    Id = 1,
                    RoleName = "Admin",
                    Description = "System Administrator with full access",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new Roles
                {
                    Id = 2,
                    RoleName = "Support",
                    Description = "Support staff who handle feedback",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new Roles
                {
                    Id = 3,
                    RoleName = "Customer",
                    Description = "Customer who can submit feedback",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                }
            );

            // Seed default feedback statuses
            modelBuilder.Entity<FeedbackStatuses>().HasData(
                new FeedbackStatuses
                {
                    Id = 1,
                    StatusName = "Open",
                    Description = "New feedback submitted",
                    ColorCode = "#3B82F6",
                    IsDefault = 1,
                    IsFinalStatus = 0,
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackStatuses
                {
                    Id = 2,
                    StatusName = "In Progress",
                    Description = "Feedback is being worked on",
                    ColorCode = "#F59E0B",
                    IsDefault = 0,
                    IsFinalStatus = 0,
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackStatuses
                {
                    Id = 3,
                    StatusName = "Pending Review",
                    Description = "Waiting for review",
                    ColorCode = "#8B5CF6",
                    IsDefault = 0,
                    IsFinalStatus = 0,
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackStatuses
                {
                    Id = 4,
                    StatusName = "Resolved",
                    Description = "Feedback has been resolved",
                    ColorCode = "#10B981",
                    IsDefault = 0,
                    IsFinalStatus = 1,
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackStatuses
                {
                    Id = 5,
                    StatusName = "Closed",
                    Description = "Feedback is closed",
                    ColorCode = "#6B7280",
                    IsDefault = 0,
                    IsFinalStatus = 1,
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackStatuses
                {
                    Id = 6,
                    StatusName = "Rejected",
                    Description = "Feedback was rejected",
                    ColorCode = "#EF4444",
                    IsDefault = 0,
                    IsFinalStatus = 1,
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                }
            );

            // Seed default priorities
            modelBuilder.Entity<FeedbackPriorities>().HasData(
                new FeedbackPriorities
                {
                    Id = 1,
                    PriorityName = "Critical",
                    PriorityLevel = 1,
                    Description = "Critical issue requiring immediate attention",
                    ColorCode = "#DC2626",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackPriorities
                {
                    Id = 2,
                    PriorityName = "High",
                    PriorityLevel = 2,
                    Description = "High priority issue",
                    ColorCode = "#EA580C",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackPriorities
                {
                    Id = 3,
                    PriorityName = "Medium",
                    PriorityLevel = 3,
                    Description = "Medium priority issue",
                    ColorCode = "#D97706",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackPriorities
                {
                    Id = 4,
                    PriorityName = "Low",
                    PriorityLevel = 4,
                    Description = "Low priority issue",
                    ColorCode = "#65A30D",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackPriorities
                {
                    Id = 5,
                    PriorityName = "Enhancement",
                    PriorityLevel = 5,
                    Description = "Feature enhancement request",
                    ColorCode = "#0891B2",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                }
            );

            // Seed default categories
            modelBuilder.Entity<FeedbackCategories>().HasData(
                new FeedbackCategories
                {
                    Id = 1,
                    CategoryName = "Bug Report",
                    Description = "Software bugs and issues",
                    ColorCode = "#DC2626",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackCategories
                {
                    Id = 2,
                    CategoryName = "Feature Request",
                    Description = "New feature suggestions",
                    ColorCode = "#059669",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackCategories
                {
                    Id = 3,
                    CategoryName = "Performance",
                    Description = "Performance related issues",
                    ColorCode = "#D97706",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackCategories
                {
                    Id = 4,
                    CategoryName = "User Interface",
                    Description = "UI/UX related feedback",
                    ColorCode = "#7C3AED",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackCategories
                {
                    Id = 5,
                    CategoryName = "Documentation",
                    Description = "Documentation improvements",
                    ColorCode = "#0891B2",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                },
                new FeedbackCategories
                {
                    Id = 6,
                    CategoryName = "General",
                    Description = "General feedback and suggestions",
                    ColorCode = "#6B7280",
                    Status = 1,
                    IsDelete = 0,
                    CreatedByUserId = 1,
                    CreatedDate = defaultDate,
                    ModifiedByUserId = 1,
                    ModifiedDate = defaultDate
                }
            );
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.Entity.GetType().GetProperty("ModifiedDate") != null)
                {
                    entry.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Added && entry.Entity.GetType().GetProperty("CreatedDate") != null)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                }
            }
        }
    }
}