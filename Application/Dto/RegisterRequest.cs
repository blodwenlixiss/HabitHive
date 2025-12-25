using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Application.Dto;

public class RegisterRequest
{
    [MaxLength(15)] public required string FirstName { get; set; }
    [MaxLength(30)] public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? UserName { get; set; }
    public required string Password { get; set; }
    public Roles Role { get; set; }
}