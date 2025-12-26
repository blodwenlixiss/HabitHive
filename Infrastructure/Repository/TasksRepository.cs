using Domain.Entity;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TasksRepository : ITasksRepository
{
    private readonly DbSet<UserTask> _tasks;

    public TasksRepository(AppDbContext context)
    {
        _tasks = context.Set<UserTask>();
    }


    public async Task AddTaskForUserAsync(UserTask userTask)
    {
        await _tasks.AddAsync(userTask);
    }

    public async Task<IEnumerable<UserTask>> GetUserTasksAsync(string userId)
    {
        var tasks = await _tasks
            .Where(t => t.UserId == userId)
            .ToListAsync();

        return tasks;
    }

    public Task<UserTask?> GetUserTaskByIdAsync(Guid taskId, string userId)
    {
        var task = _tasks
            .FirstOrDefault(t => t.UserId == userId & t.Id == taskId);

        return Task.FromResult(task);
    }

    public Task DeleteTaskByIdAsync(UserTask task)
    {
        _tasks.Remove(task);
        return Task.FromResult(task);
    }
}