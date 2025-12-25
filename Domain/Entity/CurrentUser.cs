namespace Domain.Entity;

public class CurrentUser
{
    public readonly string Id;
    public readonly string Email;
    public readonly IEnumerable<string> Roles;

    public CurrentUser(string id, string email, IEnumerable<string> roles)
    {
        Id = id;
        Email = email;
        Roles = roles;
    }
}