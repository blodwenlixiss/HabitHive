using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entity;

public class Notification
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Message { get; set; }

    public NotificationeEnum NotificationType { get; set; }

    public bool IsRead { get; set; }
    
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ScheduledFor { get; set; }
    
    public required string UserId { get; set; }

    [ForeignKey("UserId")] public ApplicationUser? User { get; set; }
    
    public Guid? TaskId { get; set; }
    [ForeignKey("TaskId")] public UserTask? Task { get; set; }
    
    public Guid? HobbyId { get; set; }
    [ForeignKey("HobbyId")] public Hobby? Hobby { get; set; }
}