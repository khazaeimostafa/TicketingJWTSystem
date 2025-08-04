using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Application.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid? AssignedToUserId { get; set; }
    }
}