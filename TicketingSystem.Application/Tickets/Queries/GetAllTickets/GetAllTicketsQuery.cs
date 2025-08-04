using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Application.Tickets.Queries.GetAllTickets;

public class GetAllTicketsQuery : IRequest<List<GetAllTicketsQueryResponse>>
{
    // نیازی به پارامتر نداره چون قراره همه‌ی تیکت‌ها رو بیاره
}
