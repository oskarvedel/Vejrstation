using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Vejrstation.Entities;


namespace Vejrstation.Hubs
{
    public class LiveUpdateHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }

    }
}
