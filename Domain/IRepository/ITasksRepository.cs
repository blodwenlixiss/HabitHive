using Domain.Entity;

namespace Domain.IRepository;

public interface ITasksRepository
{
    Task AddTaskForUserAsync(UserTask userTask);
    Task<IEnumerable<UserTask>> GetUserTasksAsync(string userId);
    Task<UserTask?> GetUserTaskByIdAsync(Guid taskId, string userId);
    Task DeleteTaskByIdAsync(UserTask task);
}