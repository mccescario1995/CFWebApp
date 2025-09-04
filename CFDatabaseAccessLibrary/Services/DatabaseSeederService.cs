//using CFDatabaseAccessLibrary.DataAccess;
////using CFDatabaseAccessLibrary.DataSeeding;
//using Microsoft.Extensions.Logging;

//namespace CFDatabaseAccessLibrary.Services
//{
//    public interface IDatabaseSeederService
//    {
//        Task SeedDatabaseAsync();
//        Task ResetAndSeedAsync();
//    }

//    public class DatabaseSeederService : IDatabaseSeederService
//    {
//        private readonly CFContext _context;
//        private readonly ILogger<DatabaseSeederService> _logger;

//        public DatabaseSeederService(CFContext context, ILogger<DatabaseSeederService> logger)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        public async Task SeedDatabaseAsync()
//        {
//            try
//            {
//                _logger.LogInformation("Starting database seeding...");
//                await DatabaseSeeder.SeedAsync(_context);
//                _logger.LogInformation("Database seeding completed successfully!");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error occurred during database seeding");
//                throw;
//            }
//        }

//        public async Task ResetAndSeedAsync()
//        {
//            try
//            {
//                _logger.LogInformation("Resetting database and reseeding...");

//                // Delete database and recreate (BE CAREFUL - THIS DELETES ALL DATA!)
//                await _context.Database.EnsureDeletedAsync();
//                await _context.Database.EnsureCreatedAsync();

//                await DatabaseSeeder.SeedAsync(_context);
//                _logger.LogInformation("Database reset and seeding completed successfully!");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error occurred during database reset and seeding");
//                throw;
//            }
//        }
//    }
//}