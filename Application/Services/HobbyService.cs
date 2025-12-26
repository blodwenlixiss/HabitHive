using System.Runtime.InteropServices.JavaScript;
using Application.Dto;
using Application.IServices;
using Application.Mapper;
using Domain.Entity;
using Domain.IRepository;

namespace Application.Services;

public class HobbyService : IHobbyService
{
    private readonly IUnityOfWork _unityOfWork;

    public HobbyService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public async Task CreateHobby(HobbyRequest hobbyRequest)
    {
        var currentUser = _unityOfWork.UserState.GetCurrentUser();
        var hobby = hobbyRequest.ToHobbyRequestMapper(currentUser.Id);
        hobby.IsActive = true;
        await _unityOfWork.HobbiesRepository.CreateHobby(hobby);
        await _unityOfWork.SaveChangesAsync();
    }


    public async Task<IEnumerable<HobbyResponse>> GetAllUserHobby()
    {
        var currentUser = _unityOfWork.UserState.GetCurrentUser();
        var hobbyList = await _unityOfWork.HobbiesRepository.GetAllHobbiesAsync(currentUser.Id);
        var hobbies = hobbyList.ToHobbyResponseMapper();
        return hobbies;
    }

    public async Task<HobbyResponse> GetUserHobbyByIdAsync(Guid hobbyId)
    {
        var currentUser = _unityOfWork.UserState.GetCurrentUser();
        var hobby = await _unityOfWork.HobbiesRepository.GetHobbyByIdAsync(hobbyId, currentUser.Id);
        var hobbyResponse = hobby.ToHobbyResponseMapper();
        return hobbyResponse;
    }

    public async Task CompleteHobbyAsync(Guid hobbyId)
    {
        var currentUser = _unityOfWork.UserState.GetCurrentUser();
        var today = DateTime.Today;
        var hobby = await _unityOfWork.HobbiesRepository.GetHobbyByIdAsync(hobbyId, currentUser.Id);
        var alreadyCompelted = await _unityOfWork.HobbiesRepository.IsHobbyCompletedAsync(hobbyId, currentUser.Id, today);


        if (alreadyCompelted)
        {
            throw new Exception();
        }

        var completion = new HobbyCompletion
        {
            Id = Guid.NewGuid(),
            HobbyId = hobbyId,
            UserId = currentUser.Id,
            CompletedAt = DateTime.Today,
            DateCompleted = today,
        };

        await _unityOfWork.HobbiesRepository.AddHobbyCompletion(completion);


        UpdateStreak(hobby, today);

        await _unityOfWork.SaveChangesAsync();
    }

    private void UpdateStreak(Hobby hobby, DateTime today)
    {
        if (hobby.LastCompletedDate == today.AddDays(-1))
        {
            hobby.CurrentStreak++;
        }
        else
        {
            hobby.CurrentStreak = 1;
        }

        hobby.LastCompletedDate = today;

        if (hobby.CurrentStreak > hobby.LongestStreak)
        {
            hobby.LongestStreak = hobby.CurrentStreak;
        }
    }
}