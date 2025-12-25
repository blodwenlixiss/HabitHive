using Domain.Enum;

namespace Application.Dto;

public class TaskRequest
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    
    public CategoryEnum Category { get; set; }
    public PriorityEnum Priority { get; set; }
    
    public DateTime DueTime { get; set; }
}