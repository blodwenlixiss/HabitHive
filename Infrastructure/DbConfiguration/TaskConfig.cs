using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Domain.Entity.Task;

namespace Infrastructure.DbConfiguration;

public class TaskConfig : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(t => t.Id);

        builder
            .Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(t => t.Description)
            .HasMaxLength(1000);
        
        builder.HasIndex(t => t.UserId);
        builder.HasIndex(t => t.DueTime);
        builder.HasIndex(t => t.IsCompleted);

        builder
            .HasOne(t => t.ApplicationUser)
            .WithMany(t => t.Tasks)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}