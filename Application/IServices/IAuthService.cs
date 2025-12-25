using Application.Dto;

namespace Application.IServices;

public interface IAuthService
{
    Task CreateUserAsync(RegisterRequest registerDto);
    Task<AuthResponse> LoginAsync(AuthRequest loginDto);
}