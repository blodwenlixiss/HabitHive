using Application.Dto;
using Application.IServices;
using Domain.CostumExceptions;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RegisterRequest = Application.Dto.RegisterRequest;

namespace Web.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUserAsync([FromBody] RegisterRequest registerRequest)
    {
        await _authService.CreateUserAsync(registerRequest);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] AuthRequest authRequest)
    {
        var loginResult = await _authService.LoginAsync(authRequest);

        var result = ResponseModel<object>.SuccessMessage(new
        {
            loginResult.AccessToken,
            loginResult.RefreshToken
        });

        return Ok(result);
    }
}