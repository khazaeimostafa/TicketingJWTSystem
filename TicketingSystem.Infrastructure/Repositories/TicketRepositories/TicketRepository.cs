using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;
using TicketingSystem.Application.Tickets.Queries.GetTicketGroupedCountByStats;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Enums;
using TicketingSystem.Infrastructure.Data;

namespace TicketingSystem.Infrastructure.Repositories.TicketRepositories;
public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Tickets.Include(x => x.AssignedToUser).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Ticket>> GetAllAsync(CancellationToken cancellationToken = default)
     => await _context.Tickets.ToListAsync();


    public async Task AddAsync(Ticket ticket, CancellationToken cancellationToken = default)
    {
        await _context.Tickets.AddAsync(ticket);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket != null)
            _context.Tickets.Remove(ticket);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
     => await _context.SaveChangesAsync(cancellationToken);


    public async Task<List<Ticket>> GetTicketsByCreatorAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .Where(t => t.CreatedByUserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<GetTicketGroupedByStatusCountQueryResponse> GetTicketsStatsAsync(CancellationToken cancellationToken)
    {
        var stats = await _context.Tickets.GroupBy(x => x.Status).Select(t => new { Status = t.Key, Count = t.Count() }).ToListAsync(cancellationToken);
        return new GetTicketGroupedByStatusCountQueryResponse
        {
            ClosedCount = stats.FirstOrDefault(x => x.Status ==   TicketStatus.Closed)?.Count ?? 0,
            InProgressCount = stats.FirstOrDefault(x => x.Status ==  TicketStatus.InProgress)?.Count ?? 0,
            OpenCount = stats.FirstOrDefault(x => x.Status == TicketStatus.Open)?.Count ?? 0,
        };
    }

    public async Task<bool> ExistsWithTitleAsync(string title, CancellationToken cancellationToken)
     => await _context.Tickets.AnyAsync(x => x.Title.ToLower().Trim() == title.ToLower().Trim(), cancellationToken);

}
