using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfiguration;

public class HobbyConfig :IEntityTypeConfiguration<Hobby>
{
    public void Configure(EntityTypeBuilder<Hobby> builder)
    {
        builder.HasKey(h => h.Id);

        builder
            .Property(h => h.Title)
            .IsRequired()
            .HasMaxLength(200);
        builder
            .Property(h => h.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasIndex(h => h.UserId);
        builder.HasIndex(h => h.IsActive);

        builder
            .HasOne(h => h.ApplicationUser)
            .WithMany(u => u.Hobbies)
            .HasForeignKey(h => h.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}