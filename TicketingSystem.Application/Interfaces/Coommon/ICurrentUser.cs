﻿namespace TicketingSystem.Application.Interfaces.Coommon;
public interface ICurrentUser
{
    Guid UserId { get; }
    string Email { get; }
    string Role { get; }
}