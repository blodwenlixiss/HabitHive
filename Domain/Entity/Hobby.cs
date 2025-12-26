using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entity;

public class Hobby
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Title { get; set; }
    public string? Description { get; set; }

    public int CurrentStreak { get; set; }
    public int LongestStreak { get; set; }

    public HabitFrequencyEnum Frequency { get; set; }

    public bool IsActive { get; set; }

    public DateTime? LastCompletedDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public string UserId { get; set; }
    [ForeignKey("UserId")] public ApplicationUser? ApplicationUser { get; set; }


    public ICollection<HobbyCompletion>? Completions { get; set; } = [];
}