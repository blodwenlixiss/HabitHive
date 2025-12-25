using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entity;

public class UserTask
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Title { get; set; }
    public string? Description { get; set; }

    public CategoryEnum Category { get; set; }
    public PriorityEnum Priority { get; set; }

    public DateTime DueTime { get; set; }

    public bool IsCompleted { get; set; }
    public DateTime CompletedAt { get; set; }

    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; }


    [ForeignKey("UserId")] public ApplicationUser? ApplicationUser { get; set; }
}