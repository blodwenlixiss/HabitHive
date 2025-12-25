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
        IUserState userState
    )
    {
        _context = context;
        UserRepository = userRepository;
        TasksRepository = taskRepository;
        UserState = userState;
    }


    public IUserRepository UserRepository { get; }
    public ITasksRepository TasksRepository { get; }
    public IUserState UserState { get; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}