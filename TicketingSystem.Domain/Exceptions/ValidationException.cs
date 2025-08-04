using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Domain.Exceptions;
public class ValidationException : AppException
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(IDictionary<string, string[]> errors)
        : base("خطای اعتبارسنجی رخ داده است.", 400)
    {
        Errors = errors;
    }
}
