using Domain.Entity;

namespace Application.IServices;
public interface IJwtService
{
    Task<string> GenerateAccessToken(ApplicationUser user);
    public string GenerateRefreshToken();
}