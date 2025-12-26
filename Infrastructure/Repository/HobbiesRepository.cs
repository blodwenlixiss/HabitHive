using Domain.Entity;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class HobbiesRepository : IHobbiesRepository
{
    private readonly DbSet<Hobby> _hobbies;
    private readonly DbSet<HobbyCompletion> _hobbyCompletions;

    public HobbiesRepository(AppDbContext context)
    {
        _hobbies = context.Set<Hobby>();
        _hobbyCompletions = context.Set<HobbyCompletion>();
    }


    public async Task CreateHobby(Hobby hobby)
    {
        await _hobbies.AddAsync(hobby);
    }

    public async Task<IEnumerable<Hobby>> GetAllHobbiesAsync(string userId)
    {
        var hobbies = await _hobbies
            .Include(h => h.Completions)
            .Where(h => h.UserId == userId)
            .ToListAsync();
        return hobbies;
    }

    public async Task<Hobby?> GetHobbyByIdAsync(Guid hobbyId, string userId)
    {
        var hobby = await _hobbies
                        .Include(h => h.Completions)
                        .FirstOrDefaultAsync(h =>
                            h.Id == hobbyId &&
                            h.UserId == userId);
        return hobby;
    }

    public async Task AddHobbyCompletion(HobbyCompletion hobbyCompletion)
    {
        await _hobbyCompletions.AddAsync(hobbyCompletion);
    }

    public async Task<IEnumerable<HobbyCompletion>> GetHobbyCompletionHistory(string userId)
    {
        var hobbyCompletion = await _hobbyCompletions
            .Where(hc => hc.UserId == userId)
            .ToListAsync();
        return hobbyCompletion;
    }

    public async Task CompleteHobbyAsync(HobbyCompletion hobbyCompletion)
    {
        await _hobbyCompletions.AddAsync(hobbyCompletion);
    }

    public async Task<bool> IsHobbyCompletedAsync(Guid hobbyId, string userId, DateTime date)
    {
        return await _hobbyCompletions.AnyAsync(hc =>
            hc.HobbyId == hobbyId &&
            hc.UserId == userId &&
            hc.DateCompleted == date);
    }
}