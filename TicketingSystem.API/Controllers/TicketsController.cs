using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.API.RequestDTOs.TicketDTOs;
using TicketingSystem.Application.Interfaces.Coommon;
using TicketingSystem.Application.Tickets.Commands.CreateTicket;
using TicketingSystem.Application.Tickets.Commands.DeleteTicket;
using TicketingSystem.Application.Tickets.Commands.UpdateTicket;
using TicketingSystem.Application.Tickets.Queries.GetAllTickets;
using TicketingSystem.Application.Tickets.Queries.GetMyTickets;
using TicketingSystem.Application.Tickets.Queries.GetTicketById;
using TicketingSystem.Application.Tickets.Queries.GetTicketGroupedCountByStats;
using TicketingSystem.Domain.Constants;
using TicketingSystem.Domain.Exceptions;

namespace TicketingSystem.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrentUser _currentUser;
    private readonly IAuthorizationService _authorizationService;
    public TicketsController(IMediator mediator, ICurrentUser currentUser, IAuthorizationService authorizationService)
    {
        _mediator = mediator;
        _currentUser=currentUser;
        _authorizationService=authorizationService;
    }

    // فقط نقش Employee می‌تواند تیکت بسازد
    [HttpPost]
    [Authorize(Roles = RoleConsts.Employee)]
    public async Task<CreateTicketCommandResponse> CreateTicket([FromBody] CreateTicketDTOs requestDto)
     => await _mediator.Send(new CreateTicketCommand(requestDto.Title, requestDto.Description, requestDto.Priority));

    // اینجا میتونستیم پالیسی  هم تعریف کنیم ولی چون دیتا مربوط به خود کاریر هست همیشه محدود به خودشه و نیازی به اضافه  کاری نداره  
    [Authorize(Roles = RoleConsts.Employee)]
    [HttpGet("GetMyTickets")]
    public async Task<List<GetMyTicketsQueryResponse>> GetMyTickets()
     => await _mediator.Send(new GetMyTicketsQuery());


    [Authorize(Roles = RoleConsts.Admin)]
    [HttpGet("GetAllTickets")]
    public async Task<List<GetAllTicketsQueryResponse>> GetAllTickets()
     => await _mediator.Send(new GetAllTicketsQuery());

    // تغییر وضعیت و اختصاص به کاربر دیگر
    [HttpPut("UpdateTicket/{id}")]
    [Authorize(Roles = RoleConsts.Admin)]
    public async Task<UpdateTicketCommandResponse> Update([FromRoute] Guid id, [FromBody] UpdateTicketDTO requestDto)
     => await _mediator.Send(new UpdateTicketCommand(id, requestDto.Status, requestDto.AssignedToUserId));

    //نمایش تعداد تیکت‌ها به تفکیک وضعیت
    [HttpGet("GetTicketGroupedByStatsCount")]
    [Authorize(Roles = RoleConsts.Admin)]
    public async Task<GetTicketGroupedByStatusCountQueryResponse> GetTicketGroupedByStatsCount()
     => await _mediator.Send(new GetTicketGroupedByStatusCountQuery());


    [HttpGet("GetById/{id}")]
    [Authorize]
    public async Task<GetTicketByIdQueryResponse> GetById(Guid id)
    {
        //به شکل فیلتر اتریبیوت هم میشه پیشاده سازی کرد  ولی برای خوانایی بیشتر اینجا نوشتم   
        #region Policy
        var authorizationResult = await _authorizationService.AuthorizeAsync(User, id, PolicyConsts.CanViewTicket);

        if (!authorizationResult.Succeeded)
            throw new ForbiddenException("شما اجازه دسترسی به این بخش را ندارید.");
        #endregion
        return await _mediator.Send(new GetTicketByIdQuery(id));

    }


    [Authorize(Roles = RoleConsts.Admin)]
    [HttpDelete("DeleteById/{id:guid}")]
    public async Task<bool> DeleteTicket([FromRoute] Guid id)
     => await _mediator.Send(new DeleteTicketCommand(id));

}