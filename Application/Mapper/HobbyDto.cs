using Application.Dto;
using Domain.Entity;

namespace Application.Mapper;

public static class HobbyDto
{
    public static Hobby ToHobbyRequestMapper(this HobbyRequest hobbyDto, string userId)
    {
        var hobby = new Hobby
        {
            Title = hobbyDto.Title,
            Description = hobbyDto.Description,
            Frequency = hobbyDto.Frequency,
            UserId = userId,
            CreatedAt = DateTime.Today
        };

        return hobby;
    }

    public static IEnumerable<HobbyResponse> ToHobbyResponseMapper(this IEnumerable<Hobby> hobby)
    {
        var today = DateTime.UtcNow.Date;

        var hobbies = hobby.Select(h => new HobbyResponse
        {
            Id = h.Id,
            Title = h.Title,
            Description = h.Description,
            Frequency = h.Frequency,
            CurrentStreak = h.CurrentStreak,
            LongestStreak = h.LongestStreak,
            IsActive = h.IsActive,
            IsCompletedToday = h.Completions
                .Any(c => c.DateCompleted == today),
            CreatedAt = h.CreatedAt
        });

        return hobbies;
    }


    public static HobbyResponse ToHobbyResponseMapper(this Hobby hobby)
    {
        var today = DateTime.UtcNow.Date;

        return new HobbyResponse
        {
            Id = hobby.Id,
            Title = hobby.Title,
            Description = hobby.Description,
            Frequency = hobby.Frequency,
            CurrentStreak = hobby.CurrentStreak,
            LongestStreak = hobby.LongestStreak,
            IsActive = hobby.IsActive,
            IsCompletedToday = hobby.Completions
                .Any(c => c.DateCompleted == today),
            CreatedAt = hobby.CreatedAt
        };
    }
}