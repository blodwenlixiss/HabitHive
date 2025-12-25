using System.Security.Cryptography;
using Application.Dto;
using Application.IServices;
using Application.Mapper;
using Domain.Entity;
using Domain.IRepository;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IJwtService _jwtService;

    public AuthService
    (
        UserManager<ApplicationUser> manager,
        IUnityOfWork unityOfWork,
        IJwtService jwtService
    )
    {
        _unityOfWork = unityOfWork;
        _userManager = manager;
        _jwtService = jwtService;
    }


    public async Task CreateUserAsync(RegisterRequest registerDto)
    {
        var applicationUser = registerDto.ToRegisterDtoMapper();

        var userExist = await _unityOfWork.UserRepository
            .GetUserByEmailAsync(registerDto.Email);
        if (userExist != null)
        {
            throw new Exception("User with this email already exists");
        }
        var result = await _userManager.CreateAsync(applicationUser, registerDto.Password);
    
        if (!result.Succeeded)
        {
            throw new Exception($"User creation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        await _userManager.AddToRoleAsync(applicationUser, registerDto.Role.ToRoleName());
    }

    public async Task<AuthResponse> LoginAsync(AuthRequest loginDto)
    {
        var applicationUser = await _unityOfWork.UserRepository.GetUserByEmailAsync(loginDto.Email);


        var accessToken = await _jwtService.GenerateAccessToken(applicationUser);
        var refreshToken = _jwtService.GenerateRefreshToken();

        var response = new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return response;
    }

    public async Task LogoutAsync()
    {
        throw new NotImplementedException();
    }
}