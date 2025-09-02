using CFDatabaseAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CFDatabaseAccessLibrary.DataAccess
{
    public class CFContext : DbContext
    {
        public CFContext(DbContextOptions<CFContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Users> Users { get; set; }
        public DbSet<UserProfiles> UserProfiles { get; set; }
        public DbSet<UserEmployments> UserEmployements { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserAddresses> UserAddresses { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Feedbacks> Feedbacks { get; set; }
        public DbSet<FeedbackComments> FeedbackComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //--------------------------------------------
            // Default values for Status / Isdelete
            //--------------------------------------------
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.Isdelete).HasDefaultValue(0);
            });

            modelBuilder.Entity<UserProfiles>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.Isdelete).HasDefaultValue(0);
            });

            modelBuilder.Entity<UserEmployments>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.Isdelete).HasDefaultValue(0);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.Isdelete).HasDefaultValue(0);
            });

            modelBuilder.Entity<UserAddresses>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.Isdelete).HasDefaultValue(0);
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.Isdelete).HasDefaultValue(0);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.Isdelete).HasDefaultValue(0);
            });

            modelBuilder.Entity<Feedbacks>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.Isdelete).HasDefaultValue(0);
            });

            modelBuilder.Entity<FeedbackComments>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValue(1);
                entity.Property(e => e.Isdelete).HasDefaultValue(0);
            });

            //--------------------------------------------
            // Relationships (FKs)
            //--------------------------------------------

            // Companies → Departments
            modelBuilder.Entity<Departments>()
                .HasOne(d => d.Company)
                .WithMany(c => c.Departments)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Companies → UserEmployments
            modelBuilder.Entity<UserEmployments>()
                .HasOne(ue => ue.Company)
                .WithMany(c => c.UserEmployments)
                .HasForeignKey(ue => ue.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Departments → UserEmployments
            modelBuilder.Entity<UserEmployments>()
                .HasOne(ue => ue.Department)
                .WithMany(d => d.UserEmployments)
                .HasForeignKey(ue => ue.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Departments → Users (Manager)
            modelBuilder.Entity<Departments>()
                .HasOne(d => d.ManagerUser)
                .WithMany()
                .HasForeignKey(d => d.ManagerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Roles → Users
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users → UserProfiles (1:1)
            modelBuilder.Entity<Users>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfiles>(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Users → UserEmployments (1:1)
            modelBuilder.Entity<Users>()
                .HasOne(u => u.UserEmployment)
                .WithOne(ue => ue.User)
                .HasForeignKey<UserEmployments>(ue => ue.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Users → UserAddresses (1:N)
            modelBuilder.Entity<UserAddresses>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAddresses)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Users → Feedbacks (Customer)
            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.Customer)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users → Feedbacks (AssignedTo)
            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.AssignedToUser)
                .WithMany()
                .HasForeignKey(f => f.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Feedbacks → FeedbackComments
            modelBuilder.Entity<FeedbackComments>()
                .HasOne(fc => fc.Feedback)
                .WithMany(f => f.FeedbackComments)
                .HasForeignKey(fc => fc.FeedbackId)
                .OnDelete(DeleteBehavior.Cascade);

            // Users → FeedbackComments
            modelBuilder.Entity<FeedbackComments>()
                .HasOne(fc => fc.User)
                .WithMany()
                .HasForeignKey(fc => fc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //--------------------------------------------
            // Seeders 
            //--------------------------------------------

            //modelBuilder.Entity<Roles>().HasData(
            //    new Roles
            //    {
            //        Id = 1,
            //        Name = "Customer",
            //        Description = "End-users who can submit feedback",
            //        Status = 1,
            //        Isdelete = 0,
            //        Createdbyuserid = 1,
            //        Modefiedbyuserid = 1
            //    },
            //    new Roles 
            //    { 
            //        Id = 2, 
            //        Name = "Support", 
                    
            //        Description = "Team members who handle feedback", 
            //        Status = 1, 
            //        Isdelete = 0, 
            //        Createdbyuserid = 1, 
            //        Modefiedbyuserid = 1 
            //    },
            //    new Roles 
            //    { 
            //        Id = 3, 
            //        Name = "Admin", 
            //        Description = "System administrators", 
            //        Status = 1, 
            //        Isdelete = 0, 
            //        Createdbyuserid = 1, 
            //        Modefiedbyuserid = 1 
            //    }
            //);

        }
    }
}
