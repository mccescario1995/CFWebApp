//using CFDatabaseAccessLibrary.Services;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace CFWeb.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class SeedController : ControllerBase
//    {
//        private readonly IDatabaseSeederService _seederService;
//        private readonly ILogger<SeedController> _logger;

//        public SeedController(IDatabaseSeederService seederService, ILogger<SeedController> logger)
//        {
//            _seederService = seederService;
//            _logger = logger;
//        }

//        /// <summary>
//        /// Seeds the database with initial data (only if database is empty)
//        /// </summary>
//        [HttpPost("seed")]
//        public async Task<IActionResult> SeedDatabase()
//        {
//            try
//            {
//                await _seederService.SeedDatabaseAsync();
//                return Ok(new { message = "Database seeded successfully!" });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Failed to seed database");
//                return BadRequest(new { error = "Failed to seed database", details = ex.Message });
//            }
//        }

//        /// <summary>
//        /// Resets and seeds the database (CAUTION: This deletes all existing data!)
//        /// </summary>
//        [HttpPost("reset-and-seed")]
//        public async Task<IActionResult> ResetAndSeedDatabase()
//        {
//            try
//            {
//                await _seederService.ResetAndSeedAsync();
//                return Ok(new { message = "Database reset and seeded successfully!" });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Failed to reset and seed database");
//                return BadRequest(new { error = "Failed to reset and seed database", details = ex.Message });
//            }
//        }
//    }
//}
