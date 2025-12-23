using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfiguration;

public class HobbyCompletionConfig : IEntityTypeConfiguration<HobbyCompletion>
{
    public void Configure(EntityTypeBuilder<HobbyCompletion> builder)
    {
        builder.HasKey(h => h.Id);

        builder
            .Property(hc => hc.CompletedAt);

        builder
            .HasOne(hc => hc.Hobby)
            .WithMany(h => h.Completions)
            .HasForeignKey(hc => hc.HobbyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(hc => hc.User)
            .WithMany(u => u.HobbyCompletions)
            .HasForeignKey(hc => hc.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
    
}