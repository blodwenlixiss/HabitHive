using Infrastructure.UserState;

namespace Domain.IRepository;

public interface IUnityOfWork
{
    public IUserRepository UserRepository { get; }
    public ITasksRepository TasksRepository { get; }
    public IHobbiesRepository HobbiesRepository { get; }
    public IUserState UserState { get; }
    Task SaveChangesAsync();
}