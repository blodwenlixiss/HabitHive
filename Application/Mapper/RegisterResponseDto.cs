using Application.Dto;
using Domain.Entity;

namespace Application.Mapper;

public static class RegisterResponseDto
{
    public static ApplicationUser ToRegisterDtoMapper(this RegisterRequest registerRequestDto)
    {
        var userName = registerRequestDto.UserName ?? registerRequestDto.Email;
        var applicationUser = new ApplicationUser
        {
            FirstName = registerRequestDto.FirstName,
            LastName = registerRequestDto.LastName,
            Email = registerRequestDto.Email,
            UserName = userName,
        };

        return applicationUser;
    }
}