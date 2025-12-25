using Domain.Entity;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly DbSet<ApplicationUser> _users;

    public UserRepository(AppDbContext dbContext)
    {
        _users = dbContext.Set<ApplicationUser>();
    }

    public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
    {
        var applicationUser = await _users
            .FirstOrDefaultAsync(u => u.Email == email);

        return applicationUser;
    }

    public async Task<bool> CheckUserByEmailAsync(string email)
    {
        var applicationUser = await _users
            .AnyAsync(u => u.Email == email);

        return applicationUser;
    }
}