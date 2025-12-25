using Domain.Entity;

namespace Infrastructure.UserState;

public interface IUserState
{
    CurrentUser GetCurrentUser();
}