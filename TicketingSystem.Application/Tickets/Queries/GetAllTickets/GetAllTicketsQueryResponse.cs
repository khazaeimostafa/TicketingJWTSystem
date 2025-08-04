namespace TicketingSystem.Application.Tickets.Queries.GetAllTickets
{
    public class GetAllTicketsQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Priority { get; set; } = default!;
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}