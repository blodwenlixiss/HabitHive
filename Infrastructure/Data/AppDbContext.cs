using Domain.Entity;
using Infrastructure.DbConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ApplicationRole> Roles { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<UserTask> Tasks { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<HobbyCompletion> HobbyCompletions { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        
        builder.ApplyConfiguration(new ApplicationUserConfig());
        builder.ApplyConfiguration(new HobbyCompletionConfig());
        builder.ApplyConfiguration(new NotificationConfig());
        builder.ApplyConfiguration(new HobbyConfig());
        builder.ApplyConfiguration(new TaskConfig());
    }
}