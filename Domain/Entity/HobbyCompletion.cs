using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

public class HobbyCompletion
{
    public Guid Id { get; set; }

    public Guid HobbyId { get; set; }
    [ForeignKey("HobbyId")] public Hobby? Hobby { get; set; }

    public required string UserId { get; set; }
    [ForeignKey("UserId")] public ApplicationUser? User { get; set; }

    public DateTime CompletedAt { get; set; }
    public DateTime DateCompleted { get; set; }

    public string? Notes { get; set; }
}