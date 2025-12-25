using Application.Dto;
using Domain.Entity;

namespace Application.Mapper;

public static class ToTaskDto
{
    public static UserTask ToUserTaskRequestMapper(this TaskRequest userTaskDto, string userId)
    {
        var task = new UserTask
        {
            Title = userTaskDto.Title,
            Description = userTaskDto.Description,
            Category = userTaskDto.Category,
            Priority = userTaskDto.Priority,
            DueTime = userTaskDto.DueTime,
            CreatedAt = DateTime.UtcNow,
            UserId = userId,
        };
        return task;
    }

    public static IEnumerable<TaskResponse> ToUserTaskResponseMapper(this IEnumerable<UserTask> userTask)
    {
        var tasks = userTask.Select(t => new TaskResponse
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            Category = t.Category,
            Priority = t.Priority,
            DueTime = t.DueTime,
            CreatedAt = t.CreatedAt,
        });

        return tasks;
    }

    public static TaskResponse ToUserTaskResponseMapper(this UserTask userTask)
    {
        var tasks = new TaskResponse
        {
            Id = userTask.Id,
            Title = userTask.Title,
            Description = userTask.Description,
            Category = userTask.Category,
            Priority = userTask.Priority,
            DueTime = userTask.DueTime,
            CreatedAt = userTask.CreatedAt,
        };

        return tasks;
    }
}