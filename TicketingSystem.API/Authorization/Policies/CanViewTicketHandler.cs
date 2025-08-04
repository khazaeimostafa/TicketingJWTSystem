using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;
using TicketingSystem.Domain.Enums;
using TicketingSystem.Infrastructure.Data;

namespace TicketingSystem.API.Authorization.Policies;

public class CanViewTicketRequirement : IAuthorizationRequirement { }
public class CanViewTicketHandler : AuthorizationHandler<CanViewTicketRequirement, Guid>
{
    private readonly ITicketRepository _ticketRepository;

    public CanViewTicketHandler(ITicketRepository ticketRepository)
    {


        _ticketRepository=ticketRepository;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        CanViewTicketRequirement requirement,
        Guid ticketId)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var role = context.User.FindFirstValue(ClaimTypes.Role);

        if (userId is null) return;

        var ticket = await _ticketRepository.GetByIdAsync(ticketId);
        if (ticket is null) return;

        if (ticket.CreatedByUserId.ToString() == userId ||
            (role == UserRole.Admin.ToString() && ticket.AssignedToUserId?.ToString() == userId))
        {
            context.Succeed(requirement);
        }
    }
}
