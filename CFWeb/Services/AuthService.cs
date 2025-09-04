// Services/AuthService.cs
using CFDatabaseAccessLibrary.DataAccess;
using CFDatabaseAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CFDatabaseAccessLibrary.DTOs;
using System.Security.Claims;
using System.Text;

namespace CFWeb.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto loginDto);
        Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto registerDto);
    }
    public class AuthService : IAuthService
    {
        private readonly CFContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(CFContext context, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto loginDto)
        {
            _logger.LogInformation("The login Credentials From Auth Service {Credentials}", System.Text.Json.JsonSerializer.Serialize(loginDto));

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null)
            {
                _logger.LogWarning("Login failed: User with email {Email} not found.", loginDto.Email);
                return new AuthResponseDto { Success = false, Message = "Invalid username or password." };
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                _logger.LogWarning("Login failed: Incorrect password for user {Email}.", loginDto.Email);
                return new AuthResponseDto { Success = false, Message = "Invalid username or password." };
            }

            var token = GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Success = true,
                Token = token,
                User = new UserDto {
                    UserId = user.Id, 
                    Email = user.Email 
                }
            };
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto registerDto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Email already registered"
                };
            }

            var user = new Users
            {
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Success = true,
                Token = token,
                User = new UserDto {
                    UserId = user.Id, 
                    Email = user.Email 
                    }
            };
        }

        private string GenerateJwtToken(Users user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!)
            );
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
