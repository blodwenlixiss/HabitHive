using Domain.Enum;

namespace Application.Dto;

public class TaskResponse
{
    public Guid Id { get; set; }

    public required string Title { get; set; }
    public string? Description { get; set; }
    
    public CategoryEnum Category { get; set; }
    public PriorityEnum Priority { get; set; }
    
    public DateTime DueTime { get; set; }
    
    public bool IsCompleted { get; set; }
    public DateTime CompletedAt { get; set; }

    public DateTime CreatedAt { get; set; }
}