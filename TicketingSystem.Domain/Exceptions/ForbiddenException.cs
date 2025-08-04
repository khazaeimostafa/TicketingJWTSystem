using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Domain.Exceptions;
public class ForbiddenException : AppException
{
    public ForbiddenException(string message)
        : base(message, 403)
    {
    }
}
