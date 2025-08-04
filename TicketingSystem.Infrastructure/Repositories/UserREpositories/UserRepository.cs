using Microsoft.EntityFrameworkCore;
using TicketingSystem.Application.Interfaces.Coommon;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Infrastructure.Data;

namespace TicketingSystem.Infrastructure.Repositories.UserREpositories;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistsAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    => await _context.SaveChangesAsync(cancellationToken);

    public async Task<bool> ISAdmin(Guid userId, CancellationToken cancellationToken = default)
    {
        // قبلا در ولیدیتور چک شده و مطمین هستیم مقدار داره  
        var user = await _context.Users.FirstAsync(x => x.Id == userId, cancellationToken);
        var check  =  user.Role == Domain.Enums.UserRole.Admin;

        return check;

    }
}
