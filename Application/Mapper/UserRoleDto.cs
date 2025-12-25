using Domain.Enum;

namespace Application.Mapper;

public static class UserRoleDto
{
    public static string ToRoleName(this Roles role)
    {
        return role.ToString();
    }

    public static Roles ToUserRole(this string roleName)
    {
        return Enum.Parse<Roles>(roleName);
    }
}