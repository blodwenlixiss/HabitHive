using Application.Dto;
using Application.IServices;
using Application.Mapper;
using Domain.Entity;
using Domain.IRepository;

namespace Application.Services;

public class TasksService : ITasksService
{
    private readonly IUnityOfWork _unityOfWork;

    public TasksService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public async Task CreateUserTaskAsync(TaskRequest taskRequest)
    {
        var currentUser = _unityOfWork.UserState.GetCurrentUser();

        var task = taskRequest.ToUserTaskRequestMapper(currentUser.Id);

        await _unityOfWork.TasksRepository.AddTaskForUserAsync(task);

        await _unityOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<TaskResponse>> GetAllTasksFromUserAsync()
    {
        var currentUser = _unityOfWork.UserState.GetCurrentUser();
        var taskList = await _unityOfWork.TasksRepository
            .GetUserTasksAsync(currentUser.Id);
        var tasks = taskList.ToUserTaskResponseMapper();

        return tasks;
    }

    public async Task<TaskResponse> GetTaskByUserIdAsync(Guid taskId)
    {
        var currentUser = _unityOfWork.UserState.GetCurrentUser();
        var taskResponse = await _unityOfWork.TasksRepository.GetUserTaskByIdAsync(taskId, currentUser.Id);

        var task = taskResponse.ToUserTaskResponseMapper() ?? throw new Exception();

        return task;
    }

    public async Task DeleteTaskByIdAsync(Guid taskId)
    {
        var currentUser = _unityOfWork.UserState.GetCurrentUser();
        var task = await _unityOfWork.TasksRepository
                       .GetUserTaskByIdAsync(taskId, currentUser.Id) ??
                   throw new Exception();

        await _unityOfWork.TasksRepository.DeleteTaskByIdAsync(task);
        await _unityOfWork.SaveChangesAsync();
    }
}