using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entity;

public class ApplicationUser : IdentityUser
{
    [MaxLength(15)] public required string FirstName { get; set; }
    [MaxLength(30)] public required string LastName { get; set; }
    
    public override required string? UserName { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public ICollection<Task>? Tasks { get; set; } = [];
    public ICollection<Hobby>? Hobbies { get; set; } = [];
    
    public ICollection<HobbyCompletion>? HobbyCompletions { get; set; } = [];
    
    public ICollection<Notification>? Notifications { get; set; } = [];
    
    
}
