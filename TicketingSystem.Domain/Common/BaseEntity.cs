using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Ticket> CreatedTickets { get; set; } = new List<Ticket>();
        public ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();


    }
}
