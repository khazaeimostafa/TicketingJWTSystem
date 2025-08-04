namespace TicketingSystem.Application.Tickets.Queries.GetTicketGroupedCountByStats
{
    public class GetTicketGroupedByStatusCountQueryResponse
    {
        public int OpenCount { get; set; }
        public int InProgressCount { get; set; }
        public int ClosedCount { get; set; }

    }
}