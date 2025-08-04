using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities;

public class Ticket : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TicketStatus Status { get; private set; }
    public TicketPriority Priority { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public Guid CreatedByUserId { get; private set; }
    public User CreatedByUser { get; private set; }
    public Guid? AssignedToUserId { get; private set; }
    public User? AssignedToUser { get; private set; }

    // Constructor
    public Ticket(string title, string description, TicketPriority priority, Guid createdByUserId)
    {
        Title = title;
        Description = description;
        Priority = priority;
        Status = TicketStatus.Open;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        CreatedByUserId = createdByUserId;
    }

    // Behavior
    public void AssignToAdmin(Guid adminUserId)
    {

        AssignedToUserId = adminUserId;
    }

    public void UpdateStatus(TicketStatus newStatus)
    {
        if (!IsValidStatusTransition(newStatus))
            throw new InvalidOperationException("وضعیت جدید نامعتبر است.");

        Status = newStatus;
        UpdatedAt = DateTime.UtcNow;
    }

    private bool IsValidStatusTransition(TicketStatus newStatus)
    {

        if (Status == TicketStatus.Closed && newStatus != TicketStatus.Closed)
            return false;

        return true;
    }

    public void UpdateDetails(string title, string description, TicketPriority priority)
    {
        Title = title;
        Description = description;
        Priority = priority;

    }

    public void UpdatedAtTime()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
