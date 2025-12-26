using Domain.IRepository;
using Infrastructure.UserState;

namespace Infrastructure.Data;

public class UnityOfWork : IUnityOfWork
{
    private readonly AppDbContext _context;

    public UnityOfWork(
        AppDbContext context,
        IUserRepository userRepository,
        ITasksRepository taskRepository,
        IHobbiesRepository hobbiesRepository,
        IUserState userState
    )
    {
        _context = context;
        UserRepository = userRepository;
        TasksRepository = taskRepository;
        HobbiesRepository = hobbiesRepository;
        UserState = userState;
    }


    public IUserRepository UserRepository { get; }
    public ITasksRepository TasksRepository { get; }
    public IUserState UserState { get; }

    public IHobbiesRepository HobbiesRepository { get; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}