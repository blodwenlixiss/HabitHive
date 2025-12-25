using System.Security.Claims;
using Domain.Entity;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.UserState;

public class UserState : IUserState
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserState(IHttpContextAccessor accessor)
    {
        _httpContextAccessor = accessor;
    }

    public CurrentUser GetCurrentUser()
    {
        var user = _httpContextAccessor.HttpContext?.User ??
                   throw new Exception();

        var userId = user.FindFirst(c => c.Type == "id");
        var userEmail = user.FindFirst(c => c.Type == ClaimTypes.Email);
        var roles = user.Claims.Where(u => u.Type == ClaimTypes.Role).Select(u => u.Value);

        if (userId == null || userEmail == null)
            throw new Exception("No Authorize to this user");

        return new CurrentUser(userId.Value, userEmail.Value, roles);
    }
}