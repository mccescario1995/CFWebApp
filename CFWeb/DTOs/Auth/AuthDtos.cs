// DTOs/Auth/AuthDtos.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFWeb.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterDto
    {

        [Required]
        [Column("email", TypeName = "varchar(50)")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(20)")]
        public string Password { get; set; }

        [Required]
        [Column("roleid")]
        public int RoleId { get; set; }

    }

    public class AuthResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public UserDto? User { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
