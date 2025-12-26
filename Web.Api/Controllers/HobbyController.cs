using Application.Dto;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[controller]")]
public class HobbyController : ControllerBase
{
    private readonly IHobbyService _hobbyService;

    public HobbyController(IHobbyService hobbyService)
    {
        _hobbyService = hobbyService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateHobby([FromBody] HobbyRequest hobbyRequest)
    {
        await _hobbyService.CreateHobby(hobbyRequest);
        return Ok("Hobby creatyed");
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetHobbyList()
    {
        var hobbyList = await _hobbyService.GetAllUserHobby();
        return Ok(hobbyList);
    }

    [Authorize]
    [HttpGet("{hobbyId:guid}")]
    public async Task<IActionResult> GetHobbyByUserId(Guid hobbyId)
    {
        var hobby = await _hobbyService.GetUserHobbyByIdAsync(hobbyId);
        return Ok(hobby);
    }

    [Authorize]
    [HttpPost("{hobbyId:guid}/compelte")]
    public async Task<IActionResult> CompleteHobbyDaily(Guid hobbyId)
    {
        await _hobbyService.CompleteHobbyAsync(hobbyId);
        return Ok("updated hobby");
    }
}