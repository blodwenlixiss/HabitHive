using Application.Dto;
using Application.IServices;
using Domain.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

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

    [Authorize]
    [HttpGet("{taskId:guid}")]
    public async Task<IActionResult> CreateTaskForUser(Guid taskId)
    {
        var tasks = await _taskService.GetTaskByUserIdAsync(taskId);

        return Ok(tasks);
    }
}