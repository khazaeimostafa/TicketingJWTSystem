using TicketingSystem.Domain.Enums;

namespace TicketingSystem.API.RequestDTOs.TicketDTOs
{
    public class UpdateTicketDTO
    {

        public TicketStatus Status { get; set; }
        public Guid AssignedToUserId { get; set; }

    }
}
