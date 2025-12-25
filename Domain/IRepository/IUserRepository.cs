using Domain.Entity;

namespace Domain.IRepository;

public interface IUserRepository
{
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
    Task<bool> CheckUserByEmailAsync(string email);
}