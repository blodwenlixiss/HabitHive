using Application.Dto;
using Application.IServices;
using Domain.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

/// <summary>
/// Controller for managing authentication and user-related operations.
/// </summary>
[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITasksService _taskService;

    public TaskController(ITasksService taskService)
    {
        _taskService = taskService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateTaskForUser([FromBody] TaskRequest taskRequest)
    {
        await _taskService.CreateUserTaskAsync(taskRequest);

        return Ok("Task has been created");
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> CreateTaskForUser()
    {
        var tasks = await _taskService.GetAllTasksFromUserAsync();

        return Ok(tasks);
    }

    /// <summary>
    /// Gets all the tasks from the current user
    /// </summary>
    /// <param name="taskId">Task id to find the task</param>
    /// <returns>Task List</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /Task
    ///     {
    ///         "title": "Complete project documentation",
    ///         "description": "Write comprehensive API documentation",
    ///         "dueDate": "2024-12-31T23:59:59"
    ///     }
    /// 
    /// </remarks>
    [Authorize]
    [HttpGet("{taskId:guid}")]
    public async Task<IActionResult> CreateTaskForUser(Guid taskId)
    {
        var tasks = await _taskService.GetTaskByUserIdAsync(taskId);

        return Ok(tasks);
    }

    [Authorize]
    [HttpDelete("{taskId:guid}")]
    public async Task<IActionResult> DeleteTaskById(Guid taskId)
    {
        await _taskService.DeleteTaskByIdAsync(taskId);
        return Ok("task has been deleted successfully");
    }
}