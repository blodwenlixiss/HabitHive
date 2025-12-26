using Domain.Entity;

namespace Domain.IRepository;

public interface IHobbiesRepository
{
    Task CreateHobby(Hobby hobby);
    Task<IEnumerable<Hobby>> GetAllHobbiesAsync(string userId);
    Task<Hobby?> GetHobbyByIdAsync(Guid hobbyId, string userId);
    Task AddHobbyCompletion(HobbyCompletion hobbyCompletion);
    Task<IEnumerable<HobbyCompletion>> GetHobbyCompletionHistory(string userId);
    Task CompleteHobbyAsync(HobbyCompletion hobbyCompletion);
    Task<bool> IsHobbyCompletedAsync(Guid hobbyId, string userId, DateTime date);
}