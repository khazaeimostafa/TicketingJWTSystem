using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Application.Tickets.Queries.GetTicketGroupedCountByStats;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;
public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Ticket>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Ticket ticket, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Ticket>> GetTicketsByCreatorAsync(Guid userId, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<GetTicketGroupedByStatusCountQueryResponse> GetTicketsStatsAsync(CancellationToken cancellationToken);
    Task<bool> ExistsWithTitleAsync(string title, CancellationToken cancellationToken);
}
