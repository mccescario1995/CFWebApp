//using CFDatabaseAccessLibrary.DataAccess;
//using CFDatabaseAccessLibrary.Models;
//using Microsoft.EntityFrameworkCore;
//using BCrypt.Net;

//namespace CFDatabaseAccessLibrary.DataSeeding
//{
//    public static class DatabaseSeeder
//    {
//        public static async Task SeedAsync(CFContext context)
//        {
//            try
//            {
//                // Ensure database is created
//                await context.Database.EnsureCreatedAsync();

//                // Check if data already exists to prevent duplicate seeding
//                if (await context.Roles.AnyAsync())
//                {
//                    Console.WriteLine("Database already seeded.");
//                    return;
//                }

//                Console.WriteLine("Starting database seeding...");

//                // 1. Seed Roles (No dependencies)
//                await SeedRoles(context);

//                // 2. Seed Companies (No dependencies)
//                await SeedCompanies(context);

//                // 3. Seed Users (Depends on Roles)
//                await SeedUsers(context);

//                // 4. Seed Departments (Depends on Companies and Users for manager)
//                await SeedDepartments(context);

//                // 5. Seed User Profiles (Depends on Users)
//                await SeedUserProfiles(context);

//                // 6. Seed User Employment (Depends on Users, Companies, Departments)
//                await SeedUserEmployments(context);

//                // 7. Seed User Addresses (Depends on Users)
//                await SeedUserAddresses(context);

//                // 8. Seed Feedbacks (Depends on Users)
//                await SeedFeedbacks(context);

//                // 9. Seed Feedback Comments (Depends on Feedbacks and Users)
//                await SeedFeedbackComments(context);

//                Console.WriteLine("Database seeding completed successfully!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error during seeding: {ex.Message}");
//                throw;
//            }
//        }

//        private static async Task SeedRoles(CFContext context)
//        {
//            var roles = new List<Roles>
//            {
//                new Roles
//                {
//                    Name = "Admin",
//                    Description = "System Administrator with full access",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new Roles
//                {
//                    Name = "Support",
//                    Description = "Support staff who handle customer feedback",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new Roles
//                {
//                    Name = "Customer",
//                    Description = "Customers who can submit feedback",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new Roles
//                {
//                    Name = "Manager",
//                    Description = "Department or team managers",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                }
//            };

//            await context.Roles.AddRangeAsync(roles);
//            await context.SaveChangesAsync();

//            Console.WriteLine("✓ Roles seeded successfully");
//        }

//        private static async Task SeedCompanies(CFContext context)
//        {
//            var companies = new List<Companies>
//            {
//                new Companies
//                {
//                    CompanyName = "TechCorp Solutions",
//                    CompanyCode = "TECH001",
//                    Industry = "Technology",
//                    CompanySize = "Large",
//                    Website = "https://techcorp.com",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new Companies
//                {
//                    CompanyName = "Global Industries",
//                    CompanyCode = "GLOB001",
//                    Industry = "Manufacturing",
//                    CompanySize = "Enterprise",
//                    Website = "https://globalind.com",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new Companies
//                {
//                    CompanyName = "StartUp Innovations",
//                    CompanyCode = "STAR001",
//                    Industry = "Software",
//                    CompanySize = "Small",
//                    Website = "https://startup-innovations.com",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                }
//            };

//            await context.Companies.AddRangeAsync(companies);
//            await context.SaveChangesAsync();

//            Console.WriteLine("✓ Companies seeded successfully");
//        }

//        private static async Task SeedUsers(CFContext context)
//        {

//            var users = new List<Users>
//            {
//                // Admin User
//                new Users
//                {
//                    Email = "admin@system.com",
//                    Password = BCrypt.Net.BCrypt.HashPassword("Admin123!"), // In production, this should be hashed
//                    RoleId = 1, // Admin
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                // Support Users
//                new Users
//                {
//                    Email = "support1@system.com",
//                    Password = BCrypt.Net.BCrypt.HashPassword("Support123!"),
//                    RoleId = 2, // Support
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new Users
//                {
//                    Email = "support2@system.com",
//                    Password = BCrypt.Net.BCrypt.HashPassword("Support123!"),
//                    RoleId = 2, // Support
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                // Manager
//                new Users
//                {
//                    Email = "manager@techcorp.com",
//                    Password = BCrypt.Net.BCrypt.HashPassword("Manager123!"),
//                    RoleId = 4, // Manager
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                // Customers
//                new Users
//                {
//                    Email = "john.doe@techcorp.com",
//                    Password = BCrypt.Net.BCrypt.HashPassword("Customer123!"),
//                    RoleId = 3, // Customer
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new Users
//                {
//                    Email = "jane.smith@globalind.com",
//                    Password = BCrypt.Net.BCrypt.HashPassword("Customer123!"),
//                    RoleId = 3, // Customer
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new Users
//                {
//                    Email = "mike.johnson@startup-innovations.com",
//                    Password = BCrypt.Net.BCrypt.HashPassword("Customer123!"),
//                    RoleId = 3, // Customer
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                }
//            };

//            await context.Users.AddRangeAsync(users);
//            await context.SaveChangesAsync();

//            Console.WriteLine("✓ Users seeded successfully");
//        }

//        private static async Task SeedDepartments(CFContext context)
//        {
//            // Get the manager user ID (will be auto-generated)
//            var managerUser = await context.Users
//                .Where(u => u.Email == "manager@techcorp.com")
//                .FirstOrDefaultAsync();

//            var departments = new List<Departments>
//            {
//                // TechCorp Departments
//                new Departments
//                {
//                    CompanyId = 1,
//                    DepartmentName = "Information Technology",
//                    DepartmentCode = "IT",
//                    ManagerUserId = managerUser?.Id,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new Departments
//                {
//                    CompanyId = 1,
//                    DepartmentName = "Human Resources",
//                    DepartmentCode = "HR",
//                    ManagerUserId = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                // Global Industries Departments
//                new Departments
//                {
//                    CompanyId = 2,
//                    DepartmentName = "Operations",
//                    DepartmentCode = "OPS",
//                    ManagerUserId = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                // StartUp Innovations Departments
//                new Departments
//                {
//                    CompanyId = 3,
//                    DepartmentName = "Development",
//                    DepartmentCode = "DEV",
//                    ManagerUserId = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                }
//            };

//            await context.Departments.AddRangeAsync(departments);
//            await context.SaveChangesAsync();

//            Console.WriteLine("✓ Departments seeded successfully");
//        }

//        private static async Task SeedUserProfiles(CFContext context)
//        {
//            // Get user IDs for profile creation
//            var users = await context.Users.ToListAsync();

//            var userProfiles = new List<UserProfiles>
//            {
//                new UserProfiles
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "admin@system.com")?.Id ?? 1,
//                    FirstName = "System",
//                    LastName = "Administrator",
//                    PhoneNumber = "+1234567890",
//                    ProfileImageUrl = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserProfiles
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "support1@system.com")?.Id ?? 2,
//                    FirstName = "Sarah",
//                    LastName = "Wilson",
//                    PhoneNumber = "+1234567891",
//                    ProfileImageUrl = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserProfiles
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "support2@system.com")?.Id ?? 3,
//                    FirstName = "David",
//                    LastName = "Brown",
//                    PhoneNumber = "+1234567892",
//                    ProfileImageUrl = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserProfiles
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "manager@techcorp.com")?.Id ?? 4,
//                    FirstName = "Lisa",
//                    LastName = "Garcia",
//                    PhoneNumber = "+1234567893",
//                    ProfileImageUrl = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserProfiles
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "john.doe@techcorp.com")?.Id ?? 5,
//                    FirstName = "John",
//                    LastName = "Doe",
//                    PhoneNumber = "+1234567894",
//                    ProfileImageUrl = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserProfiles
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "jane.smith@globalind.com")?.Id ?? 6,
//                    FirstName = "Jane",
//                    LastName = "Smith",
//                    PhoneNumber = "+1234567895",
//                    ProfileImageUrl = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserProfiles
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "mike.johnson@startup-innovations.com")?.Id ?? 7,
//                    FirstName = "Mike",
//                    LastName = "Johnson",
//                    PhoneNumber = "+1234567896",
//                    ProfileImageUrl = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                }
//            };

//            await context.UserProfiles.AddRangeAsync(userProfiles);
//            await context.SaveChangesAsync();
//            Console.WriteLine("✓ User Profiles seeded successfully");
//        }

//        private static async Task SeedUserEmployments(CFContext context)
//        {
//            // Get IDs from database
//            var users = await context.Users.ToListAsync();
//            var companies = await context.Companies.ToListAsync();
//            var departments = await context.Departments.ToListAsync();

//            var userEmployments = new List<UserEmployments>
//            {
//                // Manager
//                new UserEmployments
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "manager@techcorp.com")?.Id ?? 4,
//                    CompanyId = companies.FirstOrDefault(c => c.CompanyCode == "TECH001")?.Id ?? 1,
//                    DepartmentId = departments.FirstOrDefault(d => d.DepartmentCode == "IT")?.Id ?? 1,
//                    JobTitle = "IT Manager",
//                    EmployeeId = "EMP001",
//                    Startdate = "2023-01-15",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                // Customers
//                new UserEmployments
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "john.doe@techcorp.com")?.Id ?? 5,
//                    CompanyId = companies.FirstOrDefault(c => c.CompanyCode == "TECH001")?.Id ?? 1,
//                    DepartmentId = departments.FirstOrDefault(d => d.DepartmentCode == "IT")?.Id ?? 1,
//                    JobTitle = "Software Developer",
//                    EmployeeId = "EMP002",
//                    Startdate = "2023-03-01",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserEmployments
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "jane.smith@globalind.com")?.Id ?? 6,
//                    CompanyId = companies.FirstOrDefault(c => c.CompanyCode == "GLOB001")?.Id ?? 2,
//                    DepartmentId = departments.FirstOrDefault(d => d.DepartmentCode == "OPS")?.Id ?? 3,
//                    JobTitle = "Operations Specialist",
//                    EmployeeId = "EMP003",
//                    Startdate = "2023-02-15",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserEmployments
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "mike.johnson@startup-innovations.com")?.Id ?? 7,
//                    CompanyId = companies.FirstOrDefault(c => c.CompanyCode == "STAR001")?.Id ?? 3,
//                    DepartmentId = departments.FirstOrDefault(d => d.DepartmentCode == "DEV")?.Id ?? 4,
//                    JobTitle = "Full Stack Developer",
//                    EmployeeId = "EMP004",
//                    Startdate = "2023-04-01",
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                }
//            };

//            await context.UserEmployments.AddRangeAsync(userEmployments);
//            await context.SaveChangesAsync();
//            Console.WriteLine("✓ User Employments seeded successfully");
//        }

//        private static async Task SeedUserAddresses(CFContext context)
//        {
//            var users = await context.Users.ToListAsync();

//            var userAddresses = new List<UserAddresses>
//            {
//                new UserAddresses
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "john.doe@techcorp.com")?.Id ?? 5,
//                    AddressType = "Home",
//                    Address = "123 Main Street",
//                    City = "New York",
//                    State = "NY",
//                    PostalCode = "10001",
//                    Country = "USA",
//                    IsPrimary = 1,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserAddresses
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "jane.smith@globalind.com")?.Id ?? 6,
//                    AddressType = "Home",
//                    Address = "456 Oak Avenue",
//                    City = "Los Angeles",
//                    State = "CA",
//                    PostalCode = "90001",
//                    Country = "USA",
//                    IsPrimary = 1,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                },
//                new UserAddresses
//                {
//                    UserId = users.FirstOrDefault(u => u.Email == "mike.johnson@startup-innovations.com")?.Id ?? 7,
//                    AddressType = "Work",
//                    Address = "789 Innovation Drive",
//                    City = "Austin",
//                    State = "TX",
//                    PostalCode = "73301",
//                    Country = "USA",
//                    IsPrimary = 1,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = 1,
//                    Createddate = DateTime.Now,
//                    Modefiedbyuserid = 1,
//                    Modefieddate = DateTime.Now
//                }
//            };

//            await context.UserAddresses.AddRangeAsync(userAddresses);
//            await context.SaveChangesAsync();
//            Console.WriteLine("✓ User Addresses seeded successfully");
//        }

//        private static async Task SeedFeedbacks(CFContext context)
//        {
//            var users = await context.Users.ToListAsync();
//            var supportUser1 = users.FirstOrDefault(u => u.Email == "support1@system.com");
//            var supportUser2 = users.FirstOrDefault(u => u.Email == "support2@system.com");
//            var johnDoe = users.FirstOrDefault(u => u.Email == "john.doe@techcorp.com");
//            var janeSmith = users.FirstOrDefault(u => u.Email == "jane.smith@globalind.com");
//            var mikeJohnson = users.FirstOrDefault(u => u.Email == "mike.johnson@startup-innovations.com");

//            var feedbacks = new List<Feedbacks>
//            {
//                new Feedbacks
//                {
//                    CustomerId = johnDoe?.Id ?? 5,
//                    Subject = "Login Issue with New System",
//                    Description = "I'm experiencing difficulties logging into the new customer portal. The system keeps showing 'Invalid credentials' even though I'm using the correct username and password.",
//                    Priority = "High",
//                    FeedbackStatus = "Open",
//                    Category = "Technical Issue",
//                    AssignedToUserId = supportUser1?.Id,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = johnDoe?.Id ?? 5,
//                    Createddate = DateTime.Now.AddDays(-5),
//                    Modefiedbyuserid = johnDoe?.Id ?? 5,
//                    Modefieddate = DateTime.Now.AddDays(-5)
//                },
//                new Feedbacks
//                {
//                    CustomerId = janeSmith?.Id ?? 6,
//                    Subject = "Feature Request: Dark Mode",
//                    Description = "Could you please add a dark mode option to the application? It would be great for users who work late hours and prefer darker themes.",
//                    Priority = "Medium",
//                    FeedbackStatus = "InProgress",
//                    Category = "Feature Request",
//                    AssignedToUserId = supportUser2?.Id,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = janeSmith?.Id ?? 6,
//                    Createddate = DateTime.Now.AddDays(-3),
//                    Modefiedbyuserid = janeSmith?.Id ?? 6,
//                    Modefieddate = DateTime.Now.AddDays(-2)
//                },
//                new Feedbacks
//                {
//                    CustomerId = mikeJohnson?.Id ?? 7,
//                    Subject = "Slow Performance on Reports Page",
//                    Description = "The reports page takes too long to load, especially when trying to generate monthly reports. It sometimes times out completely.",
//                    Priority = "High",
//                    FeedbackStatus = "Open",
//                    Category = "Performance",
//                    AssignedToUserId = null,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = mikeJohnson?.Id ?? 7,
//                    Createddate = DateTime.Now.AddDays(-1),
//                    Modefiedbyuserid = mikeJohnson?.Id ?? 7,
//                    Modefieddate = DateTime.Now.AddDays(-1)
//                },
//                new Feedbacks
//                {
//                    CustomerId = johnDoe?.Id ?? 5,
//                    Subject = "Great UI Improvements",
//                    Description = "I love the recent updates to the user interface. The new design is much more intuitive and user-friendly. Great job!",
//                    Priority = "Low",
//                    FeedbackStatus = "Resolved",
//                    Category = "Positive Feedback",
//                    AssignedToUserId = supportUser1?.Id,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = johnDoe?.Id ?? 5,
//                    Createddate = DateTime.Now.AddDays(-7),
//                    Modefiedbyuserid = supportUser1?.Id ?? 2,
//                    Modefieddate = DateTime.Now.AddDays(-6)
//                }
//            };

//            await context.Feedbacks.AddRangeAsync(feedbacks);
//            await context.SaveChangesAsync();
//            Console.WriteLine("✓ Feedbacks seeded successfully");
//        }

//        private static async Task SeedFeedbackComments(CFContext context)
//        {
//            // Get the feedback and user IDs
//            var feedbacks = await context.Feedbacks.ToListAsync();
//            var users = await context.Users.ToListAsync();

//            var supportUser1 = users.FirstOrDefault(u => u.Email == "support1@system.com");
//            var supportUser2 = users.FirstOrDefault(u => u.Email == "support2@system.com");
//            var janeSmith = users.FirstOrDefault(u => u.Email == "jane.smith@globalind.com");

//            var loginIssueFeedback = feedbacks.FirstOrDefault(f => f.Subject.Contains("Login Issue"));
//            var darkModeFeedback = feedbacks.FirstOrDefault(f => f.Subject.Contains("Dark Mode"));
//            var uiImprovementsFeedback = feedbacks.FirstOrDefault(f => f.Subject.Contains("UI Improvements"));

//            var feedbackComments = new List<FeedbackComments>
//            {
//                // Comments for Login Issue feedback
//                new FeedbackComments
//                {
//                    FeedbackId = loginIssueFeedback?.Id ?? 1,
//                    UserId = supportUser1?.Id ?? 2,
//                    Comment = "Thank you for reporting this issue. I've assigned this to our technical team for investigation. We'll get back to you within 24 hours.",
//                    IsInternal = 0,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = supportUser1?.Id ?? 2,
//                    Createddate = DateTime.Now.AddDays(-4),
//                    Modefiedbyuserid = supportUser1?.Id ?? 2,
//                    Modefieddate = DateTime.Now.AddDays(-4)
//                },
//                new FeedbackComments
//                {
//                    FeedbackId = loginIssueFeedback?.Id ?? 1,
//                    UserId = supportUser1?.Id ?? 2,
//                    Comment = "Internal note: Need to check if this is related to the recent authentication system update.",
//                    IsInternal = 1,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = supportUser1?.Id ?? 2,
//                    Createddate = DateTime.Now.AddDays(-4),
//                    Modefiedbyuserid = supportUser1?.Id ?? 2,
//                    Modefieddate = DateTime.Now.AddDays(-4)
//                },
//                // Comments for Dark Mode Feature
//                new FeedbackComments
//                {
//                    FeedbackId = darkModeFeedback?.Id ?? 2,
//                    UserId = supportUser2?.Id ?? 3,
//                    Comment = "This is a great suggestion! I've forwarded this to our development team for consideration in the next release cycle.",
//                    IsInternal = 0,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = supportUser2?.Id ?? 3,
//                    Createddate = DateTime.Now.AddDays(-2),
//                    Modefiedbyuserid = supportUser2?.Id ?? 3,
//                    Modefieddate = DateTime.Now.AddDays(-2)
//                },
//                new FeedbackComments
//                {
//                    FeedbackId = darkModeFeedback?.Id ?? 2,
//                    UserId = janeSmith?.Id ?? 6,
//                    Comment = "Thank you for the quick response! Looking forward to this feature.",
//                    IsInternal = 0,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = janeSmith?.Id ?? 6,
//                    Createddate = DateTime.Now.AddDays(-1),
//                    Modefiedbyuserid = janeSmith?.Id ?? 6,
//                    Modefieddate = DateTime.Now.AddDays(-1)
//                },
//                // Comments for UI Improvements feedback
//                new FeedbackComments
//                {
//                    FeedbackId = uiImprovementsFeedback?.Id ?? 4,
//                    UserId = supportUser1?.Id ?? 2,
//                    Comment = "Thank you so much for the positive feedback! We really appreciate it and will share this with our development team.",
//                    IsInternal = 0,
//                    Status = 1,
//                    Isdelete = 0,
//                    Createdbyuserid = supportUser1?.Id ?? 2,
//                    Createddate = DateTime.Now.AddDays(-6),
//                    Modefiedbyuserid = supportUser1?.Id ?? 2,
//                    Modefieddate = DateTime.Now.AddDays(-6)
//                }
//            };

//            await context.FeedbackComments.AddRangeAsync(feedbackComments);
//            await context.SaveChangesAsync();
//            Console.WriteLine("✓ Feedback Comments seeded successfully");
//        }
//    }
//}