using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
        builder.Property(t => t.Description).IsRequired();
        builder.Property(t => t.Status).IsRequired();
        builder.Property(t => t.Priority).IsRequired();
    }
}