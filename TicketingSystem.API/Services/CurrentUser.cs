using System.Security.Claims;
using TicketingSystem.Application.Interfaces.Coommon;

namespace TicketingSystem.API.Services;
public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userIdClaim != null ? Guid.Parse(userIdClaim) : Guid.Empty;
        }
    }

    public string Email
    {
        get
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
        }
    }

    public string Role
    {
        get
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;
        }
    }
}