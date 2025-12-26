using Application.Dto;

namespace Application.IServices;

public interface IHobbyService
{
    Task CreateHobby(HobbyRequest hobbyRequest);
    Task<IEnumerable<HobbyResponse>> GetAllUserHobby();
    Task<HobbyResponse> GetUserHobbyByIdAsync(Guid hobbyId);
    Task CompleteHobbyAsync(Guid hobbyId);
}