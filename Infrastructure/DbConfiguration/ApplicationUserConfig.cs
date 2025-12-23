using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfiguration;

public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(15);
        
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(30);
        
        builder.HasMany(u => u.Tasks)
            .WithOne(t => t.ApplicationUser)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Hobbies)
            .WithOne(h => h.ApplicationUser)
            .HasForeignKey(h => h.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.HobbyCompletions)
            .WithOne(hc => hc.User)
            .HasForeignKey(hc => hc.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(u => u.Notifications)
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    
    }
}