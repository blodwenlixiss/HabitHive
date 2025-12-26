using Application.Dto;

namespace Application.IServices;

public interface ITasksService
{
    Task CreateUserTaskAsync(TaskRequest taskRequest);
    Task<IEnumerable<TaskResponse>> GetAllTasksFromUserAsync();
    Task<TaskResponse> GetTaskByUserIdAsync(Guid taskId);
    Task DeleteTaskByIdAsync(Guid taskId);
}