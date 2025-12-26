using Domain.Enum;

namespace Application.Dto;

public class HobbyRequest
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public HabitFrequencyEnum Frequency { get; set; }

}