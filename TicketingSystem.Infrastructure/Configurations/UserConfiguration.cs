using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasMany(u => u.CreatedTickets)
               .WithOne(t => t.CreatedByUser)
               .HasForeignKey(t => t.CreatedByUserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.AssignedTickets)
               .WithOne(t => t.AssignedToUser)
               .HasForeignKey(t => t.AssignedToUserId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}