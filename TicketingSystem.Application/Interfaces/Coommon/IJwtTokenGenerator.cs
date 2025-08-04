using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Application.Interfaces.Coommon;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
