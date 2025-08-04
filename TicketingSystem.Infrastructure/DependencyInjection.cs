using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketingSystem.Application.Interfaces.Coommon;
using TicketingSystem.Application.Interfaces.IRepositories.ITicketRepositories;
using TicketingSystem.Infrastructure.Data;
using TicketingSystem.Infrastructure.Repositories.TicketRepositories;
using TicketingSystem.Infrastructure.Repositories.UserREpositories;
using TicketingSystem.Infrastructure.Security;

namespace TicketingSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));


        // ثبت Repository

        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();


        return services;
    }
}