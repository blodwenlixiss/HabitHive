using Domain.Enum;

namespace Application.Dto;

public class HobbyResponse
{
    public Guid Id { get; set; }

    public required string Title { get; set; }
    public string? Description { get; set; }
    
    public int CurrentStreak { get; set; }
    public int LongestStreak { get; set; }
    
    public HabitFrequencyEnum Frequency { get; set; }

    public bool IsActive { get; set; }
    public bool IsCompletedToday { get; set; }
    
    public DateTime CreatedAt { get; set; }
}