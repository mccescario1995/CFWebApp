using CFDatabaseAccessLibrary.DTOs;
using CFWeb.Services;
using CFDatabaseAccessLibrary.DataAccess;
using CFDatabaseAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace CFWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CFContext _context;
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(CFContext context, IAuthService authService, ILogger<AuthController> logger)
        {
            _context = context;
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            if (response == null || !response.Success)
            {
                return BadRequest(response);
            }
            return Ok(new { success = true, token = response.Token, user = response.User });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {

            _logger.LogInformation("Attempting login for user: {Email}", loginDto.Email);

            var response = await _authService.LoginAsync(loginDto);


            _logger.LogInformation("Login response: {Response}", System.Text.Json.JsonSerializer.Serialize(response));

            if (response == null || !response.Success)
            {
                _logger.LogWarning("Login failed for user {Email}", loginDto.Email);
                return Unauthorized(response);
            }

            _logger.LogInformation("Login successful for user {Email}", loginDto.Email);
            return Ok(new { success = true, token = response.Token, user = response.User });
        }

        [HttpGet("session")]
        [Authorize]
        public async Task<IActionResult> GetSession()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (userEmail == null)
            {
                return Unauthorized();
            }

            if (user == null)
            {
                return Unauthorized();
            }

            var userSession = new
            {
                Id = user.Id,
                Email = user.Email,
            };

            return Ok(new { user = userSession });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new { success = true, message = "Logout handled on client-side." });
        }

        [HttpGet("check-email")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckEmail([FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest(new { success = false, message = "Email is required" });
            }

            var exists = await _context.Users.AnyAsync(u => u.Email == email);

            return Ok(new { exists });
        }

    }
}