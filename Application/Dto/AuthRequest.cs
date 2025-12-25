using System.ComponentModel.DataAnnotations;

namespace Application.Dto;

public class AuthRequest 
{
    [Required] public required string Email { get; set; }
    [Required] public required string Password { get; set; }
}