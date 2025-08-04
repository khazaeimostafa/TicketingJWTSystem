using TicketingSystem.Domain.Enums;

namespace TicketingSystem.API.RequestDTOs.TicketDTOs
{
    public class CreateTicketDTOs
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketPriority Priority { get; set; }

    }
}
