﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Application.UserCommandandQueries.Logins;
public class LoginCommandResponse
{
    public string Token { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
